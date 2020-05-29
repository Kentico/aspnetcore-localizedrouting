using System.Collections.Generic;

namespace Kentico.AspNetCore.LocalizedRouting
{
    public class Localized
    {
        public string OriginalName { get; set; }
        public string OriginalControllerName { get; set; }
        public List<LocalizedRoute> LocalizerRoutes { get; set; } = new List<LocalizedRoute>();

    }
}
