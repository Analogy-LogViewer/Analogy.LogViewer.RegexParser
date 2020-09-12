using Analogy.Interfaces;
using Analogy.LogViewer.RegexParser.Managers;
using Analogy.LogViewer.RegexParser.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Analogy.LogViewer.RegexParser.Properties;
using Analogy.LogViewer.Template;
using Analogy.LogViewer.Template.Managers;

namespace Analogy.LogViewer.RegexParser.IAnalogy
{
    public class RegexOfflineDataProvider : OfflineDataProvider
    {
        public override Guid Id { get; set; } = new Guid("F90ECD07-0CD4-4B90-987F-851D6BB5F11A");
        public override string OptionalTitle { get; set; } = "Regex Parser";
        public override Image SmallImage { get; set; } = Resources.AnalogyRegex32x32;

        public override Image LargeImage { get; set; } = Resources.AnalogyRegex16x16;

        public override string FileOpenDialogFilters => UserSettingsManager.UserSettings.Settings.FileOpenDialogFilters;
        public override IEnumerable<string> SupportFormats => UserSettingsManager.UserSettings.Settings.SupportFormats;

        public override string InitialFolderFullPath =>
            (!string.IsNullOrEmpty(UserSettingsManager.UserSettings.Settings.Directory) &&
             Directory.Exists(UserSettingsManager.UserSettings.Settings.Directory))
                ? UserSettingsManager.UserSettings.Settings.Directory
                : Environment.CurrentDirectory;

        private RegexParser Parser { get; set; }
        public RegexOfflineDataProvider() : this(true)
        {
        }

        public RegexOfflineDataProvider(bool updateUiAfterEachLine)
        {
            Parser = new RegexParser(UserSettingsManager.UserSettings.Settings.RegexPatterns, updateUiAfterEachLine,
                LogManager.Instance);
        }
        public override async Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler)
        {
            if (CanOpenFile(fileName))
            {
                Parser.SetRegexPatterns(UserSettingsManager.UserSettings.Settings.RegexPatterns);
                return await Parser.ParseLog(fileName, token, messagesHandler);

            }
            AnalogyLogMessage m = new AnalogyLogMessage($"File {fileName} is not supported", AnalogyLogLevel.Warning, AnalogyLogClass.General, OptionalTitle);
            messagesHandler.AppendMessage(m, OptionalTitle);
            return new List<AnalogyLogMessage> { m };
        }
      
    }
}
