using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using System;
using System.Collections.Generic;
using System.Drawing;
using Analogy.LogViewer.RegexParser.Properties;
using Analogy.LogViewer.Template;

namespace Analogy.LogViewer.RegexParser.IAnalogy
{
    public class RegexPrimaryFactory : PrimaryFactory
    {
        internal static Guid Id = new Guid("7DA2570C-92AA-423F-BCD8-43BB877463F6");
        public override Guid FactoryId { get; set; } = Id;
        public override string Title { get; set; } = "Regular Expression Parser";
        public override IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = ChangeLogList.GetChangeLog();
        public override IEnumerable<string> Contributors { get; set; } = new List<string> { "Lior Banai" };
        public override string About { get; set; } = "Regular Expression Parser for Analogy Log Viewer";
        public override Image SmallImage { get; set; } = Resources.AnalogyRegex32x32;
        public override Image LargeImage { get; set; } = Resources.AnalogyRegex16x16;

    }
}