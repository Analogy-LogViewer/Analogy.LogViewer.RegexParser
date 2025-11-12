using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.RegexParser.Managers;
using Analogy.LogViewer.RegexParser.Properties;
using Analogy.LogViewer.Template;
using Analogy.LogViewer.Template.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.LogViewer.RegexParser.IAnalogy
{
    public class RegexOfflineDataProvider : OfflineDataProviderWinForms
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

        private AnalogyRegexParser Parser { get; set; }
        public RegexOfflineDataProvider() : this(true)
        {
        }

        public RegexOfflineDataProvider(bool updateUiAfterEachLine)
        {
            Parser = new AnalogyRegexParser(UserSettingsManager.UserSettings.Settings.RegexPatterns, updateUiAfterEachLine,
                LogManager.Instance);
        }
        public override async Task<IEnumerable<IAnalogyLogMessage>> Process(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler)
        {
            if (CanOpenFile(fileName))
            {
                DateTimeOffset start = DateTimeOffset.Now;
                RaiseProcessingStarted(new AnalogyStartedProcessingArgs(start, ""));
                Parser.SetRegexPatterns(UserSettingsManager.UserSettings.Settings.RegexPatterns);
                var result = await Parser.ParseLog(fileName, token, messagesHandler);
                RaiseProcessingFinished(new AnalogyEndProcessingArgs(start, DateTime.Now, "", result.Count));
                return result;
            }
            AnalogyLogMessage m = new AnalogyLogMessage($"File {fileName} is not supported", AnalogyLogLevel.Warning, AnalogyLogClass.General, OptionalTitle);
            messagesHandler.AppendMessage(m, OptionalTitle);
            return new List<AnalogyLogMessage> { m };
        }
    }
}