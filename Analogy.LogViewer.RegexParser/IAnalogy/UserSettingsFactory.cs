using Analogy.LogViewer.RegexParser.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Interfaces;

namespace Analogy.LogViewer.RegexParser.IAnalogy
{
    public class UserSettingsFactory : IAnalogyDataProviderSettings
    {
        public virtual string Title { get; set; } = "Regex User Settings";
        public virtual UserControl DataProviderSettings { get; set; } = new RegexSettingsUC();
        public virtual Image SmallImage { get; set; } = Resources.AnalogyRegex16x16;
        public virtual Image LargeImage { get; set; } = Resources.AnalogyRegex32x32;
        public virtual Guid FactoryId { get; set; } = PrimaryFactory.Id;
        public virtual Guid Id { get; set; } = new Guid("108B0266-E0FB-4A02-B62F-DBB55CA4FEF8");

        public virtual Task SaveSettingsAsync()
        {
            ((RegexSettingsUC)DataProviderSettings)?.SaveSettings();
            return Task.CompletedTask;
        }
    }
}
