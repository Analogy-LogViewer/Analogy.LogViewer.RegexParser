using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Analogy.LogViewer.RegexParser;
using Analogy.LogViewer.RegexParser.IAnalogy;

namespace Analogy.LogViewer.Serilog.UnitTests
{
    [TestClass]
    public class JsonParserTests
    {
        [TestMethod]
        public async Task ClefParserTest()
        {
            var p = new RegexOfflineDataProvider();
            p.SupportFormats=new List<string>(){"*.nlog"};
            CancellationTokenSource cts = new CancellationTokenSource();
            string fileName = @"example.nlog";
            MessageHandlerForTesting forTesting = new MessageHandlerForTesting();

            var regexPattern = new RegexPattern(@"(?<Date>\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}.\d{4})\|(?<Level>\w+)\|(?<Source>.+)\|(?<Text>.*)\|(?<ProcessName>.*)\|(?<ProcessId>.*)",
                "yyyy-MM-dd HH:mm:ss.ffff", "", new List<string> { "*.nlog" });
            if (!RegexParser.Managers.UserSettingsManager.UserSettings.Settings.RegexPatterns.Contains(regexPattern))
                RegexParser.Managers.UserSettingsManager.UserSettings.Settings.RegexPatterns.Insert(0, regexPattern);

            var messages = await p.Process(fileName, cts.Token, forTesting);
            Assert.IsTrue(messages.Count() == 4);
        }
    }
}
