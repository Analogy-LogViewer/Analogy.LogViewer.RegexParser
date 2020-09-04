using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.RegexParser.IAnalogy
{
    public class DataProvidersFactory : IAnalogyDataProvidersFactory
    {
        public Guid FactoryId { get; set; } = PrimaryFactory.Id;
        public string Title { get; set; } = "Regular Expression Parser";

        public IEnumerable<IAnalogyDataProvider> DataProviders { get; } =
            new List<IAnalogyDataProvider> { new OfflineDataProvider() };

    }
}
