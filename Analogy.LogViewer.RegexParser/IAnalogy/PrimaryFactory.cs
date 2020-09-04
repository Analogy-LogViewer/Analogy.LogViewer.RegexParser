﻿using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.RegexParser.IAnalogy
{
    public class PrimaryFactory : IAnalogyFactory
    {
        internal static Guid Id = new Guid("7DA2570C-92AA-423F-BCD8-43BB877463F6");
        public Guid FactoryId { get; set; } = Id;
        public string Title { get; set; } = "Regular Expression Parser";
        public IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = ChangeLogList.GetChangeLog();
        public IEnumerable<string> Contributors { get; set; } = new List<string> { "Lior Banai" };
        public string About { get; set; } = "Regular Expression Parser for Analogy Log Viewer";
    }
}