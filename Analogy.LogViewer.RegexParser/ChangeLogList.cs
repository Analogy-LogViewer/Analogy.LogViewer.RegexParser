using Analogy.Interfaces;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.RegexParser
{
    public static class ChangeLogList
    {
        public static IEnumerable<AnalogyChangeLog> GetChangeLog()
        {
            return new List<AnalogyChangeLog>
            {
                new AnalogyChangeLog("Implement using template", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2020, 09, 12), ""),
                new AnalogyChangeLog("Improve Regex Parser performance #24", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2020, 09, 06), ""),
                new AnalogyChangeLog("File is used by another process issue. #11", AnalogChangeLogType.Bug, "Lior Banai", new DateTime(2020, 07, 06), ""),
                new AnalogyChangeLog("Initial version", AnalogChangeLogType.None, "Lior Banai", new DateTime(2020, 04, 27), ""),
            };
        }
    }
}