using System;
using System.Drawing;
using Analogy.Interfaces;
using Analogy.LogViewer.RegexParser.Properties;

namespace Analogy.LogViewer.RegexParser.IAnalogy
{
    public class RegexComponentImages : IAnalogyComponentImages
    {
        public Image GetLargeImage(Guid analogyComponentId)
        {
            if (analogyComponentId == PrimaryFactory.Id)
                return Resources.AnalogyRegex32x32;
            return null;
        }

        public Image GetSmallImage(Guid analogyComponentId)
        {
            if (analogyComponentId == PrimaryFactory.Id)
                return Resources.AnalogyRegex16x16;
            return null;
        }

        public Image GetOnlineConnectedLargeImage(Guid analogyComponentId) => null;

        public Image GetOnlineConnectedSmallImage(Guid analogyComponentId) => null;

        public Image GetOnlineDisconnectedLargeImage(Guid analogyComponentId) => null;

        public Image GetOnlineDisconnectedSmallImage(Guid analogyComponentId) => null;
    }
}
