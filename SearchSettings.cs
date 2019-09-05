using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace TestFileSearcher
{
	public static class SearchSettings
	{
		public static string FileNameMask { get; set; }
		public static string FileTextSearch { get; set; }
		public static bool AndFlag { get; set; }
		public static string RootDirPath { get; set; }

		public static bool BadSettings()
		{
			return string.IsNullOrWhiteSpace(RootDirPath) || (string.IsNullOrWhiteSpace(FileTextSearch) && string.IsNullOrWhiteSpace(FileNameMask))
				|| FileTextSearch.Length > 50 || FileNameMask.Length > 50;
		}

		public static void SaveSettingsToConfig()
		{
			Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

			config.AppSettings.Settings.Remove("FileNameMask");
			config.AppSettings.Settings.Remove("FileTextSearch");
			config.AppSettings.Settings.Remove("AndSearchType");
			config.AppSettings.Settings.Remove("RootDirPath");
			config.Save();

			config.AppSettings.Settings.Add("FileNameMask", FileNameMask);
			config.AppSettings.Settings.Add("FileTextSearch", FileTextSearch);
			config.AppSettings.Settings.Add("AndSearchType", AndFlag ? "TRUE" : "FALSE");
			config.AppSettings.Settings.Add("RootDirPath", RootDirPath);
			config.Save();
		}
		public static void GetSettingsFromConfig()
		{
			FileNameMask = ConfigurationManager.AppSettings["FileNameMask"].NullWhitespaceToEmpty();
			FileTextSearch = ConfigurationManager.AppSettings["FileTextSearch"].NullWhitespaceToEmpty();
			AndFlag = ConfigurationManager.AppSettings["AndSearchType"].NullWhitespaceToEmpty().ToUpper() == "TRUE";
			RootDirPath = ConfigurationManager.AppSettings["RootDirPath"].NullWhitespaceToEmpty();
		}

		
	}
}
