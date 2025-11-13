using Analogy.Interfaces.WinForms;
using Analogy.LogViewer.Template.WinForms;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.RegexParser.IAnalogy
{
    public class RegexDataProvidersFactory : DataProvidersFactoryWinForms
    {
        public override Guid FactoryId { get; set; } = RegexPrimaryFactory.Id;
        public override string Title { get; set; } = "Regular Expression Parser";
        public override IEnumerable<IAnalogyDataProviderWinForms> DataProviders { get; } = new List<IAnalogyDataProviderWinForms> { new RegexOfflineDataProvider() };
    }
}