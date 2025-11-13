using Analogy.LogViewer.RegexParser.Properties;
using Analogy.LogViewer.Template.WinForms;
using Microsoft.Extensions.Logging;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.RegexParser.IAnalogy
{
    public class RegexUserSettingsFactory : TemplateUserSettingsFactoryWinForms
    {
        public override string Title { get; set; } = "Regex User Settings";
        public override UserControl DataProviderSettings { get; set; }
        public override Image SmallImage { get; set; } = Resources.AnalogyRegex16x16;
        public override Image LargeImage { get; set; } = Resources.AnalogyRegex32x32;
        public override Guid FactoryId { get; set; } = RegexPrimaryFactory.Id;
        public override Guid Id { get; set; } = new Guid("108B0266-E0FB-4A02-B62F-DBB55CA4FEF8");

        public override void CreateUserControl(ILogger logger)
        {
           DataProviderSettings = new RegexSettingsUC();
        }

        public override Task SaveSettingsAsync()
        {
            ((RegexSettingsUC)DataProviderSettings)?.SaveSettings();
            return Task.CompletedTask;
        }
    }
}