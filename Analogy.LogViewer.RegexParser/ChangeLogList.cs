using Analogy.Interfaces;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.RegexParser
{
    public static class ChangeLogList
    {
        public static IEnumerable<AnalogyChangeLog> GetChangeLog()
        {
            yield return new AnalogyChangeLog("Initial version", AnalogChangeLogType.None, "Lior Banai", new DateTime(2019, 12, 14));
        }
    }
}
