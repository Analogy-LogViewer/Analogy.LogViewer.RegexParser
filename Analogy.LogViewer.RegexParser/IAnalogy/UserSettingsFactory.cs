﻿using Analogy.DataProviders.Extensions;
using Analogy.LogViewer.RegexParser.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.RegexParser.IAnalogy
{
    public class UserSettingsFactory : IAnalogyDataProviderSettings
    {
        public string Title { get; } = "Regex User Settings";
        public UserControl DataProviderSettings { get; } = new SerilogUCSettings();
        public Image SmallImage { get; } = Resources.AnalogySerilog16x16;
        public Image LargeImage { get; } = Resources.AnalogySerilog32x32;
        public Guid FactoryId { get; set; } = PrimaryFactory.Id;
        public Guid ID { get; set; } = new Guid("108B0266-E0FB-4A02-B62F-DBB55CA4FEF8");

        public Task SaveSettingsAsync()
        {
            ((SerilogUCSettings)DataProviderSettings)?.SaveSettings();
            return Task.CompletedTask;
        }
    }
}
