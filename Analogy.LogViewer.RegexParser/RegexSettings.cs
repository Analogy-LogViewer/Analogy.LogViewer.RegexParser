using System.Collections.Generic;
using System.Linq;

namespace Analogy.LogViewer.RegexParser
{
    public class RegexSettings
    {
        public string FileOpenDialogFilters { get; set; }
        public List<string> SupportFormats => RegexPatterns.SelectMany(r => r.SupportFormats).ToList();
        public List<RegexPattern> RegexPatterns { get; set; }
        public string Directory { get; set; }

        public RegexSettings()
        {
            Directory = string.Empty;
            FileOpenDialogFilters = "All Supported formats (*.log)|*.log|Plain log text file (*.log)|*.log";
            RegexPatterns = new List<RegexPattern>
            {
                new RegexPattern(
                    @"\$(?<Date>\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2},\d{3})+\|+(?<Thread>\d+)+\|(?<Level>\w+)+\|+(?<Source>.*)\|(?<Text>.*)",
                    "yyyy-MM-dd HH:mm:ss,fff", "", new List<string> {"*.log"})
            };
        }




    }
}
