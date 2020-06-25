using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.RegexParser
{
    [Serializable]
    public class RegexPattern
    {
        public string Pattern { get; set; }
        public string DateTimeFormat { get; set; }
        public string GuidFormat { get; set; }
        public List<string> SupportFormats { get; set; }
        public bool IsSet => !string.IsNullOrEmpty(Pattern) && !string.IsNullOrEmpty(DateTimeFormat);
        public RegexPattern()
        {
            Pattern = string.Empty;
            DateTimeFormat = "yyyy-MM-dd HH:mm:ss,fff";
            GuidFormat = string.Empty;
            SupportFormats = new List<string>();

        }
        public RegexPattern(string pattern, string dateTimeFormat, string guidFormat, List<string> supportFormats)
        {
            Pattern = pattern;
            DateTimeFormat = dateTimeFormat;
            GuidFormat = guidFormat;
            SupportFormats = supportFormats ?? new List<string>();
        }

        public override string ToString()
        {
            return $"{nameof(Pattern)}: {Pattern}, {nameof(DateTimeFormat)}: {DateTimeFormat}, {nameof(GuidFormat)}: {GuidFormat}, {nameof(SupportFormats)}: {string.Join(";", SupportFormats)}";
        }
    }
}
