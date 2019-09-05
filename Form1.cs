using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Threading;

namespace TestFileSearcher
{
	public partial class SearchForm : Form
	{
		private bool SearchStarted, SearchPaused;
		private int time = 0;
		private static long searchedFiles = 0;
		private static ManualResetEvent _busy = new ManualResetEvent(false);
		private void PushToSettings()
		{
			SearchSettings.FileNameMask = FilenameTextbox.Text;
			SearchSettings.AndFlag = ANDrb.Checked;
			SearchSettings.FileTextSearch = ContainTextbox.Text;
		}

		private void SetConfig(bool val)
		{
			ChoseRootDirButton.Enabled = val;
			FilenameTextbox.Enabled = val;
			ContainTextbox.Enabled = val;
			ANDrb.Enabled = val;
			ORrb.Enabled = val;
		}
		private void DisableConfig()
		{
			SetConfig(false);
		}
		private void EnableConfig()
		{
			SetConfig(true);
		}

		public SearchForm()
		{
			InitializeComponent();

			SearchStarted = false;
			SearchPaused = false;

			SearchSettings.GetSettingsFromConfig();

			RootDirectoryLabel.Text = string.IsNullOrWhiteSpace(SearchSettings.RootDirPath) ? "Выберите корневую директорию" : SearchSettings.RootDirPath;
			FilenameTextbox.Text = SearchSettings.FileNameMask;
			ContainTextbox.Text = SearchSettings.FileTextSearch;

			if (SearchSettings.AndFlag)
			{
				ANDrb.Checked = true;
			}
			else
			{
				ORrb.Checked = true;
			}

			FileTreeView.ImageList = new ImageList();
		}

		private void StartStopSearchButton_Click(object sender, EventArgs e)
		{
			PushToSettings();

			if (SearchSettings.BadSettings())
			{
				MessageBox.Show("Ошибка! \nНужно задать корневую директорию и хотя бы один фильтр, и их длина должна быть не больше 50 символов.");
				return;
			}

			SearchStarted = !SearchStarted;

			if (SearchStarted)
			{
				DisableConfig();
				PauseResumeSearchButton.Enabled = true;
				StartStopSearchButton.Text = "Stop";
				BackgroundSearcher.RunWorkerAsync();
				SearchTimer.Start();
			}
			else
			{
				BackgroundSearcher.CancelAsync();
				SearchPaused = false;
				EnableConfig();
				PauseResumeSearchButton.Text = "Pause";
				PauseResumeSearchButton.Enabled = false;
				SearchTimer.Stop();
			}
		}

		private void PauseResumeSearchButton_Click(object sender, EventArgs e)
		{
			SearchPaused = !SearchPaused;

			if (SearchPaused)
			{
				_busy.Reset();
				PauseResumeSearchButton.Text = "Resume";
				SearchTimer.Stop();
			}
			else
			{
				PauseResumeSearchButton.Text = "Pause";
				_busy.Set();
				SearchTimer.Start();
			}

			SearchSettings.SaveSettingsToConfig();
		}

		private void BackgroundSearcher_DoWork(object sender, DoWorkEventArgs e)
		{
			ProcessCurrentDirectory(SearchSettings.RootDirPath);
			SearchPaused = false;
			SearchStarted = false;
			this.Invoke(
				new MethodInvoker(delegate 
				{
					EnableConfig();
					PauseResumeSearchButton.Text = "Pause";
					PauseResumeSearchButton.Enabled = false;
					SearchTimer.Stop();
					StartStopSearchButton.Text = "Start";
				})
				);
			
			BackgroundSearcher.CancelAsync();
		}

		private void ChoseRootDirButton_Click(object sender, EventArgs e)
		{
			if (RootSearchDirectoryPicker.ShowDialog() == DialogResult.OK)
			{
				SearchSettings.RootDirPath = RootSearchDirectoryPicker.SelectedPath;
				RootDirectoryLabel.Text = RootSearchDirectoryPicker.SelectedPath;
			}
		}

		private void DelegateAddFileToTree(FileInfo file)
		{
			var rootDir = new DirectoryInfo(SearchSettings.RootDirPath);
			List<DirectoryInfo> parents = new List<DirectoryInfo>();
			DirectoryInfo current = file.Directory;
			parents.Add(current);

			while (current.FullName != rootDir.FullName)
			{
				current = current.Parent;
				parents.Add(current);
			}

			parents.Reverse();

			if (FileTreeView.Nodes.Count == 0)
			{
				TreeNode root = new TreeNode();
				root.Name = rootDir.FullName;
				root.Text = rootDir.Name;
				FileTreeView.Nodes.Add(root);
			}

			TreeNode currentNode = FileTreeView.Nodes[0];
			int currentParentIndex = 1;
			while (currentParentIndex < parents.Count)
			{
				bool found = false;
				int foundIndex = 0;
				for (int i = 0; i < currentNode.Nodes.Count; ++i)
				{
					if (currentNode.Nodes[i].Name == parents[currentParentIndex].FullName)
					{
						found = true;
						foundIndex = i;
						break;
					}
				}
				if (found)
				{
					++currentParentIndex;
					currentNode = currentNode.Nodes[foundIndex];
				}
				else
				{
					break;
				}
			}

			for (int i = currentParentIndex; i < parents.Count; ++i)
			{
				var child = new TreeNode();
				child.Text = parents[i].Name;
				child.Name = parents[i].FullName;
				currentNode.Nodes.Add(child);
				currentNode = child;
			}

			var leaf = new TreeNode();
			leaf.Text = file.Name;
			leaf.Name = file.FullName;
			currentNode.Nodes.Add(leaf);
		}

		private void AddFileToTree(FileInfo file)
		{
			this.Invoke(
				new MethodInvoker(
					delegate
					{
						DelegateAddFileToTree(file);
					}
				)
			);
		}

		private void UpdateSearchedNum()
		{
			++searchedFiles;
			this.Invoke(
					new MethodInvoker(
						delegate
						{
							FoundLabel.Text = "Обработано: " + searchedFiles.ToString();
						}
					)
				);
		}

		private void SearchTimer_Tick(object sender, EventArgs e)
		{
			++time;
			TimeLabel.Text = "Затрачено секунд: " + time.ToString();
		}

		private void SearchForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			SearchSettings.SaveSettingsToConfig();
		}

		private void ProcessCurrentDirectory(string Path)
		{
			try
			{
				DirectoryInfo directory = new DirectoryInfo(Path);
				var files = directory.GetFiles();
				var subdirs = directory.GetDirectories();
				foreach (var file in files)
				{
					//_busy.WaitOne(Timeout.Infinite);
					this.Invoke(
						new MethodInvoker(
							delegate
							{
								CurrentFileNameLabel.Text = file.Name;
							}
						)
					);

					bool IsFileOK = false;

					bool NameOK;
					if (!string.IsNullOrWhiteSpace(SearchSettings.FileNameMask))
					{
						NameOK = FileChecker.CheckName(file.Name, SearchSettings.FileNameMask);

						if (NameOK && (!SearchSettings.AndFlag || string.IsNullOrWhiteSpace(SearchSettings.FileTextSearch)))
						{
							IsFileOK = true;
						}
						else if (!NameOK && SearchSettings.AndFlag && !string.IsNullOrWhiteSpace(SearchSettings.FileTextSearch))
						{
							UpdateSearchedNum();
							continue;
						}
					}
					if (!IsFileOK && !string.IsNullOrWhiteSpace(SearchSettings.FileTextSearch))
					{
						IsFileOK = FileChecker.CheckContent(file, SearchSettings.FileTextSearch);
					}

					if (IsFileOK)
					{
						AddFileToTree(file);
					}
					UpdateSearchedNum();
				}

				foreach (var subdir in subdirs)
				{
					ProcessCurrentDirectory(subdir.FullName);
				}
			}
			catch (Exception ex) { }
		}
	}
}
