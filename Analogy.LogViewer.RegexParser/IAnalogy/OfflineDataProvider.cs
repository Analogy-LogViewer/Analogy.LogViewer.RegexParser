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

namespace Analogy.LogViewer.RegexParser.IAnalogy
{
    public class OfflineDataProvider : IAnalogyOfflineDataProvider
    {
        public Guid Id { get; } = new Guid("F90ECD07-0CD4-4B90-987F-851D6BB5F11A");
        public string OptionalTitle { get; } = "Regex Parser";
        public Image LargeImage => null;
        public Image SmallImage => null;

        public bool CanSaveToLogFile { get; } = false;
        public string FileOpenDialogFilters => UserSettingsManager.UserSettings.Settings.FileOpenDialogFilters;
        public string FileSaveDialogFilters { get; } = string.Empty;
        public IEnumerable<string> SupportFormats => UserSettingsManager.UserSettings.Settings.SupportFormats;
        public bool DisableFilePoolingOption { get; } = false;

        public string InitialFolderFullPath =>
            (!string.IsNullOrEmpty(UserSettingsManager.UserSettings.Settings.Directory) &&
             Directory.Exists(UserSettingsManager.UserSettings.Settings.Directory))
                ? UserSettingsManager.UserSettings.Settings.Directory
                : Environment.CurrentDirectory;
        public bool UseCustomColors { get; set; } = false;
        public IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();

        public (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);

        private RegexParser Parser { get; set; }
        public OfflineDataProvider()
        {
            Parser = new RegexParser(UserSettingsManager.UserSettings.Settings.RegexPatterns, false,
                LogManager.Instance);
        }
        public async Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler)
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


        public IEnumerable<FileInfo> GetSupportedFiles(DirectoryInfo dirInfo, bool recursiveLoad)
        => GetSupportedFilesInternal(dirInfo, recursiveLoad);

        public Task SaveAsync(List<AnalogyLogMessage> messages, string fileName)
        {
            throw new NotImplementedException();
        }

        public bool CanOpenFile(string fileName)
        {
            return UserSettingsManager.UserSettings.Settings.SupportFormats.Any(pattern =>
                PatternMatcher.StrictMatchPattern(pattern, fileName));
        }

        public bool CanOpenAllFiles(IEnumerable<string> fileNames) => fileNames.All(CanOpenFile);


        public Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            return Task.CompletedTask;

        }

        public void MessageOpened(AnalogyLogMessage message)
        {
            //nop
        }

        public static List<FileInfo> GetSupportedFilesInternal(DirectoryInfo dirInfo, bool recursive)
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
