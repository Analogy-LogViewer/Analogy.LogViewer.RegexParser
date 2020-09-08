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

namespace Analogy.LogViewer.RegexParser.IAnalogy
{
    public class OfflineDataProvider : IAnalogyOfflineDataProvider
    {
        public virtual Guid Id { get; set; } = new Guid("F90ECD07-0CD4-4B90-987F-851D6BB5F11A");
        public virtual string OptionalTitle { get; set; } = "Regex Parser";
        public virtual Image SmallImage { get; set; } = Resources.AnalogyRegex32x32;

        public virtual Image LargeImage { get; set; } = Resources.AnalogyRegex16x16;

        public virtual bool CanSaveToLogFile { get; } = false;
        public virtual string FileOpenDialogFilters => UserSettingsManager.UserSettings.Settings.FileOpenDialogFilters;
        public virtual string FileSaveDialogFilters { get; } = string.Empty;
        public virtual IEnumerable<string> SupportFormats => UserSettingsManager.UserSettings.Settings.SupportFormats;
        public virtual bool DisableFilePoolingOption { get; } = false;

        public virtual string InitialFolderFullPath =>
            (!string.IsNullOrEmpty(UserSettingsManager.UserSettings.Settings.Directory) &&
             Directory.Exists(UserSettingsManager.UserSettings.Settings.Directory))
                ? UserSettingsManager.UserSettings.Settings.Directory
                : Environment.CurrentDirectory;
        public virtual bool UseCustomColors { get; set; } = false;
        public virtual IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();

        public virtual (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);

        private RegexParser Parser { get; set; }
        public OfflineDataProvider()
        {
            Parser = new RegexParser(UserSettingsManager.UserSettings.Settings.RegexPatterns, false,
                LogManager.Instance);
        }
        public virtual async Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler)
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


        public virtual IEnumerable<FileInfo> GetSupportedFiles(DirectoryInfo dirInfo, bool recursiveLoad)
        => GetSupportedFilesInternal(dirInfo, recursiveLoad);

        public virtual Task SaveAsync(List<AnalogyLogMessage> messages, string fileName)
        {
            return Task.CompletedTask;
        }

        public virtual bool CanOpenFile(string fileName)
        {
            return UserSettingsManager.UserSettings.Settings.SupportFormats.Any(pattern =>
                PatternMatcher.StrictMatchPattern(pattern, fileName));
        }

        public virtual bool CanOpenAllFiles(IEnumerable<string> fileNames) => fileNames.All(CanOpenFile);


        public virtual Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            return Task.CompletedTask;

        }

        public virtual void MessageOpened(AnalogyLogMessage message)
        {
            //nop
        }

        protected static List<FileInfo> GetSupportedFilesInternal(DirectoryInfo dirInfo, bool recursive)
        {
            List<FileInfo> files = new List<FileInfo>();
            foreach (string pattern in UserSettingsManager.UserSettings.Settings.SupportFormats)
            {
                files.AddRange(dirInfo.GetFiles(pattern).ToList());
            }

            if (!recursive)
                return files;
            try
            {
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    files.AddRange(GetSupportedFilesInternal(dir, true));
                }
            }
            catch (Exception)
            {
                return files;
            }

            return files;
        }
    }
}
