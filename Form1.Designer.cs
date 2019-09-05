namespace TestFileSearcher
{
	partial class SearchForm
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
			this.FileTreeView = new System.Windows.Forms.TreeView();
			this.SearchTimer = new System.Windows.Forms.Timer(this.components);
			this.RootSearchDirectoryPicker = new System.Windows.Forms.FolderBrowserDialog();
			this.SettingsPanel = new System.Windows.Forms.Panel();
			this.PauseResumeSearchButton = new System.Windows.Forms.Button();
			this.StartStopSearchButton = new System.Windows.Forms.Button();
			this.ORrb = new System.Windows.Forms.RadioButton();
			this.ANDrb = new System.Windows.Forms.RadioButton();
			this.ContainTextbox = new System.Windows.Forms.TextBox();
			this.ContainTextLabel = new System.Windows.Forms.Label();
			this.FilenameTextbox = new System.Windows.Forms.TextBox();
			this.FilenameLabel = new System.Windows.Forms.Label();
			this.ChoseRootDirButton = new System.Windows.Forms.Button();
			this.RootDirectoryLabel = new System.Windows.Forms.Label();
			this.BackgroundSearcher = new System.ComponentModel.BackgroundWorker();
			this.panel1 = new System.Windows.Forms.Panel();
			this.TimeLabel = new System.Windows.Forms.Label();
			this.FoundLabel = new System.Windows.Forms.Label();
			this.CurrentFileNameLabel = new System.Windows.Forms.Label();
			this.SettingsPanel.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// FileTreeView
			// 
			this.FileTreeView.Location = new System.Drawing.Point(12, 12);
			this.FileTreeView.Name = "FileTreeView";
			this.FileTreeView.Size = new System.Drawing.Size(270, 426);
			this.FileTreeView.TabIndex = 0;
			// 
			// SearchTimer
			// 
			this.SearchTimer.Interval = 1000;
			this.SearchTimer.Tick += new System.EventHandler(this.SearchTimer_Tick);
			// 
			// SettingsPanel
			// 
			this.SettingsPanel.Controls.Add(this.PauseResumeSearchButton);
			this.SettingsPanel.Controls.Add(this.StartStopSearchButton);
			this.SettingsPanel.Controls.Add(this.ORrb);
			this.SettingsPanel.Controls.Add(this.ANDrb);
			this.SettingsPanel.Controls.Add(this.ContainTextbox);
			this.SettingsPanel.Controls.Add(this.ContainTextLabel);
			this.SettingsPanel.Controls.Add(this.FilenameTextbox);
			this.SettingsPanel.Controls.Add(this.FilenameLabel);
			this.SettingsPanel.Controls.Add(this.ChoseRootDirButton);
			this.SettingsPanel.Controls.Add(this.RootDirectoryLabel);
			this.SettingsPanel.Location = new System.Drawing.Point(288, 12);
			this.SettingsPanel.Name = "SettingsPanel";
			this.SettingsPanel.Size = new System.Drawing.Size(500, 225);
			this.SettingsPanel.TabIndex = 1;
			// 
			// PauseResumeSearchButton
			// 
			this.PauseResumeSearchButton.Enabled = false;
			this.PauseResumeSearchButton.Location = new System.Drawing.Point(88, 198);
			this.PauseResumeSearchButton.Name = "PauseResumeSearchButton";
			this.PauseResumeSearchButton.Size = new System.Drawing.Size(75, 23);
			this.PauseResumeSearchButton.TabIndex = 9;
			this.PauseResumeSearchButton.Text = "Pause";
			this.PauseResumeSearchButton.UseVisualStyleBackColor = true;
			this.PauseResumeSearchButton.Click += new System.EventHandler(this.PauseResumeSearchButton_Click);
			// 
			// StartStopSearchButton
			// 
			this.StartStopSearchButton.Location = new System.Drawing.Point(6, 199);
			this.StartStopSearchButton.Name = "StartStopSearchButton";
			this.StartStopSearchButton.Size = new System.Drawing.Size(75, 23);
			this.StartStopSearchButton.TabIndex = 8;
			this.StartStopSearchButton.Text = "Start";
			this.StartStopSearchButton.UseVisualStyleBackColor = true;
			this.StartStopSearchButton.Click += new System.EventHandler(this.StartStopSearchButton_Click);
			// 
			// ORrb
			// 
			this.ORrb.AutoSize = true;
			this.ORrb.Checked = true;
			this.ORrb.Location = new System.Drawing.Point(6, 101);
			this.ORrb.Name = "ORrb";
			this.ORrb.Size = new System.Drawing.Size(49, 17);
			this.ORrb.TabIndex = 7;
			this.ORrb.TabStop = true;
			this.ORrb.Text = "ИЛИ";
			this.ORrb.UseVisualStyleBackColor = true;
			// 
			// ANDrb
			// 
			this.ANDrb.AutoSize = true;
			this.ANDrb.Location = new System.Drawing.Point(6, 77);
			this.ANDrb.Name = "ANDrb";
			this.ANDrb.Size = new System.Drawing.Size(33, 17);
			this.ANDrb.TabIndex = 6;
			this.ANDrb.Text = "И";
			this.ANDrb.UseVisualStyleBackColor = true;
			// 
			// ContainTextbox
			// 
			this.ContainTextbox.Location = new System.Drawing.Point(6, 141);
			this.ContainTextbox.Name = "ContainTextbox";
			this.ContainTextbox.Size = new System.Drawing.Size(178, 20);
			this.ContainTextbox.TabIndex = 5;
			// 
			// ContainTextLabel
			// 
			this.ContainTextLabel.AutoSize = true;
			this.ContainTextLabel.Location = new System.Drawing.Point(3, 125);
			this.ContainTextLabel.Name = "ContainTextLabel";
			this.ContainTextLabel.Size = new System.Drawing.Size(181, 13);
			this.ContainTextLabel.TabIndex = 4;
			this.ContainTextLabel.Text = "Искать этот текст внутри файлов:";
			// 
			// FilenameTextbox
			// 
			this.FilenameTextbox.Location = new System.Drawing.Point(6, 50);
			this.FilenameTextbox.Name = "FilenameTextbox";
			this.FilenameTextbox.Size = new System.Drawing.Size(178, 20);
			this.FilenameTextbox.TabIndex = 3;
			// 
			// FilenameLabel
			// 
			this.FilenameLabel.AutoSize = true;
			this.FilenameLabel.Location = new System.Drawing.Point(3, 34);
			this.FilenameLabel.Name = "FilenameLabel";
			this.FilenameLabel.Size = new System.Drawing.Size(113, 13);
			this.FilenameLabel.TabIndex = 2;
			this.FilenameLabel.Text = "Маска имени файла:";
			// 
			// ChoseRootDirButton
			// 
			this.ChoseRootDirButton.Location = new System.Drawing.Point(368, 11);
			this.ChoseRootDirButton.Name = "ChoseRootDirButton";
			this.ChoseRootDirButton.Size = new System.Drawing.Size(129, 23);
			this.ChoseRootDirButton.TabIndex = 1;
			this.ChoseRootDirButton.Text = "Выбрать корень";
			this.ChoseRootDirButton.UseVisualStyleBackColor = true;
			this.ChoseRootDirButton.Click += new System.EventHandler(this.ChoseRootDirButton_Click);
			// 
			// RootDirectoryLabel
			// 
			this.RootDirectoryLabel.AutoSize = true;
			this.RootDirectoryLabel.Location = new System.Drawing.Point(3, 11);
			this.RootDirectoryLabel.Name = "RootDirectoryLabel";
			this.RootDirectoryLabel.Size = new System.Drawing.Size(173, 13);
			this.RootDirectoryLabel.TabIndex = 0;
			this.RootDirectoryLabel.Text = "Выберите корневую директорию";
			// 
			// BackgroundSearcher
			// 
			this.BackgroundSearcher.WorkerSupportsCancellation = true;
			this.BackgroundSearcher.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundSearcher_DoWork);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.TimeLabel);
			this.panel1.Controls.Add(this.FoundLabel);
			this.panel1.Controls.Add(this.CurrentFileNameLabel);
			this.panel1.Location = new System.Drawing.Point(288, 243);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(497, 195);
			this.panel1.TabIndex = 2;
			// 
			// TimeLabel
			// 
			this.TimeLabel.AutoSize = true;
			this.TimeLabel.Location = new System.Drawing.Point(3, 77);
			this.TimeLabel.Name = "TimeLabel";
			this.TimeLabel.Size = new System.Drawing.Size(110, 13);
			this.TimeLabel.TabIndex = 2;
			this.TimeLabel.Text = "Затрачено секунд: 0";
			// 
			// FoundLabel
			// 
			this.FoundLabel.AutoSize = true;
			this.FoundLabel.Location = new System.Drawing.Point(3, 64);
			this.FoundLabel.Name = "FoundLabel";
			this.FoundLabel.Size = new System.Drawing.Size(80, 13);
			this.FoundLabel.TabIndex = 1;
			this.FoundLabel.Text = "Обработано: 0";
			// 
			// CurrentFileNameLabel
			// 
			this.CurrentFileNameLabel.AutoSize = true;
			this.CurrentFileNameLabel.Location = new System.Drawing.Point(3, 10);
			this.CurrentFileNameLabel.Name = "CurrentFileNameLabel";
			this.CurrentFileNameLabel.Size = new System.Drawing.Size(0, 13);
			this.CurrentFileNameLabel.TabIndex = 0;
			// 
			// SearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.SettingsPanel);
			this.Controls.Add(this.FileTreeView);
			this.MaximumSize = new System.Drawing.Size(816, 489);
			this.MinimumSize = new System.Drawing.Size(816, 489);
			this.Name = "SearchForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text = "Searcher";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SearchForm_FormClosed);
			this.SettingsPanel.ResumeLayout(false);
			this.SettingsPanel.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView FileTreeView;
		private System.Windows.Forms.Timer SearchTimer;
		private System.Windows.Forms.FolderBrowserDialog RootSearchDirectoryPicker;
		private System.Windows.Forms.Panel SettingsPanel;
		private System.Windows.Forms.Button PauseResumeSearchButton;
		private System.Windows.Forms.Button StartStopSearchButton;
		private System.Windows.Forms.RadioButton ORrb;
		private System.Windows.Forms.RadioButton ANDrb;
		private System.Windows.Forms.TextBox ContainTextbox;
		private System.Windows.Forms.Label ContainTextLabel;
		private System.Windows.Forms.TextBox FilenameTextbox;
		private System.Windows.Forms.Label FilenameLabel;
		private System.Windows.Forms.Button ChoseRootDirButton;
		private System.Windows.Forms.Label RootDirectoryLabel;
		private System.ComponentModel.BackgroundWorker BackgroundSearcher;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label TimeLabel;
		private System.Windows.Forms.Label FoundLabel;
		private System.Windows.Forms.Label CurrentFileNameLabel;
	}
}

