using Analogy.Interfaces;
using Analogy.LogViewer.RegexParser.Managers;
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
        public Guid ID { get; } = new Guid("F90ECD07-0CD4-4B90-987F-851D6BB5F11A");
        public string OptionalTitle { get; } = "Regex Parser";
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

        private Regex.RegexParser Parser { get; set; }
        public OfflineDataProvider()
        {
        }
        public async Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler)
        {
            if (CanOpenFile(fileName))
            {
                switch (UserSettingsManager.UserSettings.Settings.Format)
                {

                        return await new Regex.RegexParser(UserSettingsManager.UserSettings.Settings.RegexPatterns, true,
                            LogManager.Instance).ParseLog(fileName, token, messagesHandler);
                break;
            }
        }
            return new List<AnalogyLogMessage>(0);
        }

    public IEnumerable<FileInfo> GetSupportedFiles(DirectoryInfo dirInfo, bool recursiveLoad)
        => GetSupportedFilesInternal(dirInfo, recursiveLoad);

    public Task SaveAsync(List<AnalogyLogMessage> messages, string fileName)
    {
        throw new NotImplementedException();
    }

    public bool CanOpenFile(string fileName)
    {
        return fileName.EndsWith(".Clef", StringComparison.InvariantCultureIgnoreCase);
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
        List<FileInfo> files = dirInfo.GetFiles("*.clef").ToList();
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
