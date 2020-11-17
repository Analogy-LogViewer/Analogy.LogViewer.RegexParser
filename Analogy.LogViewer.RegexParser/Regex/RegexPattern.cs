using System;
using System.Collections.Generic;
using System.Linq;

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
        public RegexPattern(string pattern, string dateTimeFormat, string guidFormat, List<string>? supportFormats)
        {
            Pattern = pattern;
            DateTimeFormat = dateTimeFormat;
            GuidFormat = guidFormat;
            SupportFormats = supportFormats ?? new List<string>();
        }

        protected bool Equals(RegexPattern other) => Pattern == other.Pattern &&
                                                     DateTimeFormat == other.DateTimeFormat &&
                                                     GuidFormat == other.GuidFormat &&
                                                     SupportFormats.SequenceEqual(other.SupportFormats);

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RegexPattern) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Pattern.GetHashCode();
                hashCode = (hashCode * 397) ^ DateTimeFormat.GetHashCode();
                hashCode = (hashCode * 397) ^ GuidFormat.GetHashCode();
                hashCode = (hashCode * 397) ^ SupportFormats.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Pattern)}: {Pattern}, {nameof(DateTimeFormat)}: {DateTimeFormat}, {nameof(GuidFormat)}: {GuidFormat}, {nameof(SupportFormats)}: {string.Join(";", SupportFormats)}";
        }
    }
}
