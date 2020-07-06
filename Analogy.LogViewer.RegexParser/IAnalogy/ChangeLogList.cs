using Analogy.Interfaces;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.RegexParser
{
    public static class ChangeLogList
    {
        public static IEnumerable<AnalogyChangeLog> GetChangeLog()
        {
            yield return new AnalogyChangeLog("File is used by another process issue. #11", AnalogChangeLogType.Bug, "Lior Banai", new DateTime(2020, 07, 06));
            yield return new AnalogyChangeLog("Initial version", AnalogChangeLogType.None, "Lior Banai", new DateTime(2020, 04, 27));
        }
    }
}
