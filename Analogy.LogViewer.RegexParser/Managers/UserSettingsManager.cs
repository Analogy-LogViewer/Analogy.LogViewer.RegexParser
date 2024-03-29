﻿using Analogy.LogViewer.Template.Managers;
using Microsoft.Extensions.Logging;
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
        public string RegexFileSetting { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Analogy.LogViewer", "AnalogyRegexSettings.json");
        public RegexSettings Settings { get; set; }

        public UserSettingsManager()
        {
            if (File.Exists(RegexFileSetting))
            {
                var settings = new JsonSerializerSettings
                {
                    ObjectCreationHandling = ObjectCreationHandling.Replace,
                };
                try
                {
                    string data = File.ReadAllText(RegexFileSetting);
                    Settings = JsonConvert.DeserializeObject<RegexSettings>(data, settings);
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
                File.WriteAllText(RegexFileSetting, JsonConvert.SerializeObject(Settings));
            }
            catch (Exception e)
            {
                LogManager.Instance.LogError(e, "Error saving settings: " + e.Message, e, "Analogy Regular Expression Parser");
            }
        }
    }
}