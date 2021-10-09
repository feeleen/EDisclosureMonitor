namespace EDisclosureMonitor
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ResultCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.StatusCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.addLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.checkAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uncheckAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.ProgressBox = new System.Windows.Forms.ToolStripProgressBar();
			this.StatusBox = new System.Windows.Forms.ToolStripStatusLabel();
			this.TimerLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ErrorStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.label4 = new System.Windows.Forms.Label();
			this.RegexBox = new System.Windows.Forms.ComboBox();
			this.AddLineBtn = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SaveListBtn = new System.Windows.Forms.Button();
			this.StartBtn = new System.Windows.Forms.Button();
			this.contextMenuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView1.CheckBoxes = true;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.ResultCol,
            this.StatusCol});
			this.listView1.ContextMenuStrip = this.contextMenuStrip1;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(12, 39);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(983, 314);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
			this.listView1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView1_ItemCheck);
			this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
			this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
			this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDoubleClick);
			this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "URL";
			this.columnHeader1.Width = 414;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Name";
			this.columnHeader2.Width = 177;
			// 
			// ResultCol
			// 
			this.ResultCol.Text = "Result";
			this.ResultCol.Width = 69;
			// 
			// StatusCol
			// 
			this.StatusCol.Text = "Status";
			this.StatusCol.Width = 318;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openURLToolStripMenuItem,
            this.copyURLToolStripMenuItem,
            this.toolStripMenuItem2,
            this.addLineToolStripMenuItem,
            this.deleteLineToolStripMenuItem,
            this.toolStripMenuItem1,
            this.checkAllToolStripMenuItem,
            this.uncheckAllToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(138, 148);
			// 
			// openURLToolStripMenuItem
			// 
			this.openURLToolStripMenuItem.Name = "openURLToolStripMenuItem";
			this.openURLToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.openURLToolStripMenuItem.Text = "Open URL";
			this.openURLToolStripMenuItem.Click += new System.EventHandler(this.openURLToolStripMenuItem_Click);
			// 
			// copyURLToolStripMenuItem
			// 
			this.copyURLToolStripMenuItem.Name = "copyURLToolStripMenuItem";
			this.copyURLToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.copyURLToolStripMenuItem.Text = "Copy URL";
			this.copyURLToolStripMenuItem.Click += new System.EventHandler(this.copyURLToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(134, 6);
			// 
			// addLineToolStripMenuItem
			// 
			this.addLineToolStripMenuItem.Name = "addLineToolStripMenuItem";
			this.addLineToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.addLineToolStripMenuItem.Text = "Add Line";
			this.addLineToolStripMenuItem.Click += new System.EventHandler(this.addLineToolStripMenuItem_Click);
			// 
			// deleteLineToolStripMenuItem
			// 
			this.deleteLineToolStripMenuItem.Name = "deleteLineToolStripMenuItem";
			this.deleteLineToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.deleteLineToolStripMenuItem.Text = "Delete Line";
			this.deleteLineToolStripMenuItem.Click += new System.EventHandler(this.deleteLineToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(134, 6);
			// 
			// checkAllToolStripMenuItem
			// 
			this.checkAllToolStripMenuItem.Name = "checkAllToolStripMenuItem";
			this.checkAllToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.checkAllToolStripMenuItem.Text = "Check All";
			this.checkAllToolStripMenuItem.Click += new System.EventHandler(this.checkAllToolStripMenuItem_Click);
			// 
			// uncheckAllToolStripMenuItem
			// 
			this.uncheckAllToolStripMenuItem.Name = "uncheckAllToolStripMenuItem";
			this.uncheckAllToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.uncheckAllToolStripMenuItem.Text = "Uncheck All";
			this.uncheckAllToolStripMenuItem.Click += new System.EventHandler(this.uncheckAllToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBox,
            this.StatusBox,
            this.TimerLabel,
            this.ErrorStatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 386);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1007, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// ProgressBox
			// 
			this.ProgressBox.Name = "ProgressBox";
			this.ProgressBox.Size = new System.Drawing.Size(300, 16);
			// 
			// StatusBox
			// 
			this.StatusBox.AutoSize = false;
			this.StatusBox.Name = "StatusBox";
			this.StatusBox.Size = new System.Drawing.Size(130, 17);
			this.StatusBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TimerLabel
			// 
			this.TimerLabel.AutoSize = false;
			this.TimerLabel.Name = "TimerLabel";
			this.TimerLabel.Size = new System.Drawing.Size(100, 17);
			// 
			// ErrorStatusLabel
			// 
			this.ErrorStatusLabel.AutoToolTip = true;
			this.ErrorStatusLabel.Name = "ErrorStatusLabel";
			this.ErrorStatusLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.ErrorStatusLabel.Size = new System.Drawing.Size(460, 17);
			this.ErrorStatusLabel.Spring = true;
			this.ErrorStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 14);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "RegEx:";
			// 
			// RegexBox
			// 
			this.RegexBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RegexBox.FormattingEnabled = true;
			this.RegexBox.Items.AddRange(new object[] {
            "(currentYear, 3 месяца|currentYear, 1 квартал)",
            "(currentYear, 6 месяцев|currentYear, 2 квартал)",
            "(currentYear, 9 месяцев|currentYear, 3 квартал)",
            "(Годовая бухгалтерская отчетность[^\\.]+?lastYear)",
            "(Годовая консолидированная финансовая отчетность по МСФО или иным международно пр" +
                "изнанным стандартам[^\\.]+?lastYear)"});
			this.RegexBox.Location = new System.Drawing.Point(51, 10);
			this.RegexBox.Name = "RegexBox";
			this.RegexBox.Size = new System.Drawing.Size(864, 21);
			this.RegexBox.TabIndex = 14;
			// 
			// AddLineBtn
			// 
			this.AddLineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.AddLineBtn.Location = new System.Drawing.Point(920, 357);
			this.AddLineBtn.Name = "AddLineBtn";
			this.AddLineBtn.Size = new System.Drawing.Size(75, 25);
			this.AddLineBtn.TabIndex = 16;
			this.AddLineBtn.Text = "Add Line";
			this.AddLineBtn.UseVisualStyleBackColor = true;
			this.AddLineBtn.Click += new System.EventHandler(this.AddLineBtn_Click_1);
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// SaveListBtn
			// 
			this.SaveListBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.SaveListBtn.Image = ((System.Drawing.Image)(resources.GetObject("SaveListBtn.Image")));
			this.SaveListBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.SaveListBtn.Location = new System.Drawing.Point(12, 357);
			this.SaveListBtn.Name = "SaveListBtn";
			this.SaveListBtn.Size = new System.Drawing.Size(111, 25);
			this.SaveListBtn.TabIndex = 15;
			this.SaveListBtn.Text = "Save List";
			this.SaveListBtn.UseVisualStyleBackColor = true;
			this.SaveListBtn.Click += new System.EventHandler(this.SaveListBtn_Click_1);
			// 
			// StartBtn
			// 
			this.StartBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.StartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.StartBtn.Image = global::EDisclosureMonitor.Properties.Resources.Play;
			this.StartBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.StartBtn.Location = new System.Drawing.Point(918, 8);
			this.StartBtn.Name = "StartBtn";
			this.StartBtn.Size = new System.Drawing.Size(78, 25);
			this.StartBtn.TabIndex = 1;
			this.StartBtn.Text = "Start";
			this.StartBtn.UseVisualStyleBackColor = true;
			this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1007, 408);
			this.Controls.Add(this.AddLineBtn);
			this.Controls.Add(this.SaveListBtn);
			this.Controls.Add(this.RegexBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.StartBtn);
			this.Controls.Add(this.listView1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(600, 39);
			this.Name = "Form1";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text = "EDisclosureMonitor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.contextMenuStrip1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button StartBtn;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripProgressBar ProgressBox;
		private System.Windows.Forms.ToolStripStatusLabel StatusBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox RegexBox;
		private System.Windows.Forms.ColumnHeader ResultCol;
		private System.Windows.Forms.ToolStripStatusLabel TimerLabel;
		private System.Windows.Forms.Button SaveListBtn;
		private System.Windows.Forms.Button AddLineBtn;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem openURLToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteLineToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel ErrorStatusLabel;
		private System.Windows.Forms.ColumnHeader StatusCol;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem checkAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uncheckAllToolStripMenuItem;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem addLineToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyURLToolStripMenuItem;
	}
}

