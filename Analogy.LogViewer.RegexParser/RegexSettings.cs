using System.Collections.Generic;

namespace Analogy.LogViewer.RegexParser
{
    public class RegexSettings
    {
        public string FileOpenDialogFilters { get; set; }
        public string FileSaveDialogFilters { get; } = string.Empty;
        public List<string> SupportFormats { get; set; }
        public List<RegexPattern> RegexPatterns { get; set; }
        public string Directory { get; set; }

        public RegexSettings()
        {
            Directory = string.Empty;
            FileOpenDialogFilters = "All Supported formats (*.log)|*.log|Plain log text file (*.log)|*.log";
            SupportFormats = new List<string> { "*.log" };
            RegexPatterns = new List<RegexPattern>();
            RegexPatterns.Add(new RegexPattern(@"\$(?<Date>\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2},\d{3})+\|+(?<Thread>\d+)+\|(?<Level>\w+)+\|+(?<Source>.*)\|(?<Text>.*)", "yyyy-MM-dd HH:mm:ss,fff", ""));

        }




    }
}
