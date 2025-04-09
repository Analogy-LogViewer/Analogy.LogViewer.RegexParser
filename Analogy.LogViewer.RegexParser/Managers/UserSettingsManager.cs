using Analogy.Interfaces;
using Analogy.LogViewer.Template.Managers;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Analogy.LogViewer.RegexParser.Managers
{
    public class UserSettingsManager
    {
        private static readonly Lazy<UserSettingsManager> _instance =
            new Lazy<UserSettingsManager>(() => new UserSettingsManager());
        public static UserSettingsManager UserSettings { get; set; } = _instance.Value;
        private string Folder { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Analogy.LogViewer");
        private string RegexFileSetting => FoldersAccess?.GetConfigurationFilePath("AnalogyRegexSettings.json") ?? Path.Combine(Folder, "AnalogyRegexSettings.json");
        private IAnalogyFoldersAccess? FoldersAccess { get; set; }
        public RegexSettings Settings { get; set; }

        public UserSettingsManager()
        {
            LoadSettings();
        }

        public void LoadSettings()
        {
            if (File.Exists(RegexFileSetting))
            {
                try
                {
                    string data = File.ReadAllText(RegexFileSetting);
                    Settings = System.Text.Json.JsonSerializer.Deserialize<RegexSettings>(data);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.LogError(ex, "Error loading user setting file", ex, "Analogy Regex Parser");
                    Settings = new RegexSettings();
                }
            }
            else
            {
                Settings = new RegexSettings();
            }
        }
        public void Save()
        {
            try
            {
                File.WriteAllText(RegexFileSetting, System.Text.Json.JsonSerializer.Serialize(Settings));
            }
            catch (Exception e)
            {
                LogManager.Instance.LogError(e, "Error saving settings: " + e.Message, e, "Analogy Regular Expression Parser");
            }
        }

        public void LoadSettings(IAnalogyFoldersAccess foldersAccess, ILogger logger)
        {
            foldersAccess.RootFolderChanged += (s, e) =>
            {
                Save();
            };
            FoldersAccess = foldersAccess;
        }
    }
}