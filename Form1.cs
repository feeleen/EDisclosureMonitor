using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Mime;
using SevenZipExtractor;

namespace EDisclosureMonitor
{
	public partial class Form1 : Form
	{
		public static readonly SemaphoreLocker locker = new SemaphoreLocker();

		public HttpService httpService;
		private static bool isWorking = false;

		private ListViewHitTestInfo hitinfo;
		private TextBox editbox = new TextBox();

		private int sortColumn = -1;
		private int timerBell = 10; //sec
		private static int counter = -1;

		string regPattern = @"(currentYear, 9 месяцев|currentYear, 3 квартал)";
		string[] regPreValues = new string[] {@"(currentYear, 3 месяца|currentYear, 1 квартал)",
@"(currentYear, 6 месяцев|currentYear, 2 квартал)",
@"(currentYear, 9 месяцев|currentYear, 3 квартал)",
@"(Годовая бухгалтерская отчетность[^\.]+?lastYear)",
@"(Годовая консолидированная финансовая отчетность по МСФО или иным международно признанным стандартам[^\.]+?lastYear)" };

		string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\urllist.txt";
		
		public CookieContainer CookiesContainer { get; set; } = new CookieContainer();

		public Form1()
		{
			InitializeComponent();

			httpService = new HttpService(ShowError);
			
			int currentYear = DateTime.Now.Year;
			int lastYear = currentYear - 1;

			regPreValues.Select(x => x.Replace(nameof(currentYear), currentYear.ToString()).Replace(nameof(lastYear), lastYear.ToString())).ToArray();

			RegexBox.Items.Clear();
			RegexBox.Items.AddRange(regPreValues.Select(x => x.Replace(nameof(currentYear), currentYear.ToString()).Replace(nameof(lastYear), lastYear.ToString())).ToArray());


			RegexBox.Text = regPattern.Replace(nameof(currentYear), currentYear.ToString());
			SettingsManager.Read(listView1, filePath);

			editbox.Parent = listView1;
			editbox.Hide();
			editbox.LostFocus += new EventHandler(editbox_LostFocus);
		}

		private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			hitinfo = listView1.HitTest(e.X, e.Y);

			if (hitinfo.SubItem != null && hitinfo.Item.SubItems.IndexOf(hitinfo.SubItem) < 2)
			{
				int X = hitinfo.SubItem.Bounds.Left;
				int width = hitinfo.SubItem.Bounds.Width;

				// the first subitem width is the width of the listview control, so we need to calculat proper width
				if (hitinfo.Item.SubItems.IndexOf(hitinfo.SubItem) == 0)
				{
					X = hitinfo.Item.Position.X;
					width -= X;
					foreach (ListViewItem.ListViewSubItem i in hitinfo.Item.SubItems)
					{
						if (hitinfo.Item.SubItems.IndexOf(i) > 0)
							width -= i.Bounds.Width;
					}
				}
				
				editbox.Bounds = new Rectangle(X, hitinfo.Item.Position.Y - 1, width, hitinfo.SubItem.Bounds.Bottom - 1);
				editbox.Text = hitinfo.SubItem.Text;
				editbox.Focus();
				editbox.Show();
			}
		}

		void editbox_LostFocus(object sender, EventArgs e)
		{
			if (hitinfo.SubItem != null)
			{
				hitinfo.SubItem.Text = editbox.Text;
				editbox.Hide();
			}
		}

		private void ShowError(string ex, string url = null)
		{
			if (InvokeRequired)
			{
				Invoke(new Action(() => ShowError(ex)));
				return;
			}

			ErrorStatusLabel.Text = ex;
			ErrorStatusLabel.ToolTipText = ErrorStatusLabel.Text;

			var currentItem = listView1.Items.Cast<ListViewItem>().Where(i => i.Text == url).FirstOrDefault();

			if (currentItem != null)
			{
				currentItem.SubItems[3].Text = ex.Replace(",", " ");
			}
		}

		private void StartBtn_Click(object sender, EventArgs e)
		{
			if (StartBtn.Text == "Stop")
			{
				timer1.Stop();
				TimerLabel.Text = "";
				StartBtn.Text = "Start";
				StartBtn.Image = Properties.Resources.Play;
			}
			else
			{
				timer1.Interval = 1;
				timer1.Enabled = true;
				counter = -1;
				timer1.Start();
				StartBtn.Text = "Stop";
				StartBtn.Image = Properties.Resources.Stop;
			}
		}

		private async Task Start()
		{
			if (InvokeRequired)
			{
				Invoke(new Func<Task>(async () => await Start()));
				return;
			}

			try
			{
				var checkedItems = listView1.Items.Cast<ListViewItem>().Where(x => x.Checked == true).ToList();
				ProgressBox.Maximum = checkedItems.Count;
				ProgressBox.Value = 0;
				StatusBox.Text = "Working...";

				foreach (var urlItem in checkedItems)
				{
					ProgressBox.Value++;
					urlItem.SubItems[2].Text = "";
					urlItem.SubItems[3].Text = "Working..";
					ErrorStatusLabel.Text = "";

					var result = await httpService.ProcessWebPageAsync(urlItem.Text, RegexBox.Text);

					if (result.StatusCode == HttpStatusCode.OK && result.FileLink.Contains("http"))
					{
						urlItem.SubItems[2].Text = "Match!";
						urlItem.Checked = false;

						PlaySound();

						// if dowload link returned - load it and extract and then open
						if (result.FileLink.Contains("http"))
						{
							urlItem.SubItems[3].Text = "Downloading..";
							ErrorStatusLabel.Text = "";
							string localFilename = await httpService.DownloadFile(result.FileLink);

							// skip if files already downloaded
							if (localFilename == string.Empty)
								continue;

							string extractDir = Path.GetDirectoryName(localFilename) + "\\extract";

							if (!Directory.Exists(extractDir))
								Directory.CreateDirectory(extractDir);

							using (ArchiveFile archiveFile = new ArchiveFile(localFilename))
							{
								archiveFile.Extract(extractDir);
							}

							foreach (string fname in Directory.GetFiles(extractDir))
							{
								Process.Start(fname);
							}
						}
					}

					urlItem.SubItems[3].Text = result.Status;
				}
			}
			finally
			{
				StatusBox.Text = "Completed";
				isWorking = false;
			}
		}

		private void PlaySound()
		{
			System.Media.SoundPlayer player = new System.Media.SoundPlayer();

			player.SoundLocation = "buttonchime02up.wav";
			player.Play();
			player.Play();
		}

		private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (e.Column != sortColumn)
			{
				sortColumn = e.Column;
				listView1.Sorting = SortOrder.Ascending;
			}
			else
			{
				if (listView1.Sorting == SortOrder.Ascending)
					listView1.Sorting = SortOrder.Descending;
				else
					listView1.Sorting = SortOrder.Ascending;
			}

			listView1.Sort();
			listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, listView1.Sorting);
		}

		private void listView1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.C)
			{
				CopyListBox(listView1);
			}
		}

		public void CopyListBox(ListView list)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var item in list.SelectedItems)
			{
				ListViewItem l = item as ListViewItem;
				if (l != null)
					foreach (ListViewItem.ListViewSubItem sub in l.SubItems)
						sb.Append(sub.Text + "\t");
				sb.AppendLine();
			}
			Clipboard.SetDataObject(sb.ToString());
		}

		private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				ProcessStartInfo StartInformation = new ProcessStartInfo();

				StartInformation.FileName = listView1.SelectedItems[0].Text;

				Process process = Process.Start(StartInformation);
			}
		}

		private bool inhibitAutoCheck;

		private void listView1_MouseUp(object sender, MouseEventArgs e)
		{
			inhibitAutoCheck = false;
		}

		private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (inhibitAutoCheck)
				e.NewValue = e.CurrentValue;
		}

		private void SaveListBtn_Click_1(object sender, EventArgs e)
		{
			SettingsManager.Save(listView1, filePath);
		}

		private void AddLineBtn_Click_1(object sender, EventArgs e)
		{
			AddNewLine();
		}

		private void AddNewLine()
		{
			string[] row = { "http://", "", "", "" };
			var listViewItem = new ListViewItem(row);
			listView1.Items.Add(listViewItem);
		}

		private void openURLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				ProcessStartInfo StartInformation = new ProcessStartInfo();

				StartInformation.FileName = listView1.SelectedItems[0].Text;

				Process process = Process.Start(StartInformation);
			}
		}

		private void deleteLineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0 && MessageBox.Show("Delete line?", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				foreach (ListViewItem lvi in listView1.SelectedItems)
					listView1.Items.Remove(lvi);
			}
		}

		private void checkAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in listView1.Items)
			{
				lvi.Checked = true;
			}
		}

		private void uncheckAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in listView1.Items)
			{
				lvi.Checked = false;
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			timer1.Stop();
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (!isWorking)
			{
				if (timer1.Interval == 1 || timerBell <= counter)
				{
					isWorking = true;
					counter = 0;
					TimerLabel.Text = "";

					Task.Run(async () =>
					{
						await locker.LockAsync(async () =>
						{
							await Start();
						});
					});
				}
				else
				{
					TimerLabel.Text = (timerBell - counter).ToString();
				}

				counter++;
			}

			if (timer1.Interval == 1)
				timer1.Interval = 1000;
		}

		private void addLineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddNewLine();
		}

		private void copyURLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count == 1)
				Clipboard.SetText(listView1.SelectedItems[0].Text);
		}
	}
}
