using Newtonsoft.Json;
using System;
using System.IO;

namespace Analogy.LogViewer.RegexParser.Managers
{
    public class UserSettingsManager
    {

        private static readonly Lazy<UserSettingsManager> _instance =
            new Lazy<UserSettingsManager>(() => new UserSettingsManager());
        public static UserSettingsManager UserSettings { get; set; } = _instance.Value;
        public string RegexFileSetting { get; private set; } = "AnalogyRegexSettings.json";
        public RegexSettings Settings { get; set; }


        public UserSettingsManager()
        {
            if (File.Exists(RegexFileSetting))
            {
                var settings = new JsonSerializerSettings
                {
                    ObjectCreationHandling = ObjectCreationHandling.Replace
                };
                try
                {
                    string data = File.ReadAllText(RegexFileSetting);
                    Settings = JsonConvert.DeserializeObject<RegexSettings>(data, settings);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.LogException(ex, "Analogy Regex Parser", "Error loading user setting file");
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
                File.WriteAllText(RegexFileSetting, JsonConvert.SerializeObject(Settings));
            }
            catch (Exception e)
            {
                LogManager.Instance.LogException(e, "Analogy Regular Expression Parser", "Error saving settings: " + e.Message);
            }


        }
    }
}
