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
            RegexPatterns = new List<RegexPattern>();
        }

        public bool Contains(RegexPattern regexPattern) => RegexPatterns.Contains(regexPattern);


    }
}
