﻿using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.Template;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.RegexParser.IAnalogy
{
    public class RegexDataProvidersFactory : DataProvidersFactory
    {
        public override Guid FactoryId { get; set; } = RegexPrimaryFactory.Id;
        public override string Title { get; set; } = "Regular Expression Parser";
        public override IEnumerable<IAnalogyDataProvider> DataProviders { get; set; } =
            new List<IAnalogyDataProvider> { new RegexOfflineDataProvider() };
    }
}