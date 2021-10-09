using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDisclosureMonitor
{
	public class SettingsManager
	{
		public static void Save(ListView lv, string filePath)
		{
			if (filePath.Length > 0)
			{
				string[] headers = lv.Columns
						   .OfType<ColumnHeader>()
						   .Select(header => header.Text.Trim())
						   .ToArray();

				string[][] items = lv.Items
							.OfType<ListViewItem>().Where(s => s.Checked == true)
							.Select(lvi => lvi.SubItems
								.OfType<ListViewItem.ListViewSubItem>()
								.Select(si => si.Text.CsvQuote()).ToArray()).ToArray();

				string[][] nonCheckedItems = lv.Items
							.OfType<ListViewItem>().Where(s => s.Checked == false)
							.Select(lvi => lvi.SubItems
								.OfType<ListViewItem.ListViewSubItem>()
								.Select(si => si.Text.CsvQuote()).ToArray()).ToArray();


				string table = "";
				foreach (string[] a in items)
				{
					table += string.Join(",", a) + ",Checked" + Environment.NewLine;
				}
				foreach (string[] a in nonCheckedItems)
				{
					table += string.Join(",", a) + "," + Environment.NewLine;
				}
				table = table.TrimEnd('\r', '\n');
				File.WriteAllText(filePath, table);
			}
		}

		public static void Read(ListView lv, string filePath)
		{
			try
			{
				if (!File.Exists(filePath))
					File.WriteAllText(filePath, "", Encoding.UTF8);

				var fileLines = File.ReadAllLines(filePath, Encoding.UTF8);

				for (int i = 0; i < fileLines.Length; i++)
				{
					List<string> names = fileLines[i].Split(',').ToList();
					ListViewItem lvi = new ListViewItem(new[]
						{
							names[0]
						});

					for (int j = 1; j < names.Count() - 1; j++)
					{
						lvi.SubItems.Add(names[j] ?? " ");
					}

					if (names.Count > 4 && names[4].ToLower() == "checked")
					{
						lvi.Checked = true;
					}

					lv.Items.Add(lvi);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Unable to read URL settings from file! (" + ex.Message + ")");
			}
		}
	}
}
