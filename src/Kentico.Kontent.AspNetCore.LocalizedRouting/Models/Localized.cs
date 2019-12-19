using System.Collections.Generic;

namespace Kentico.Kontent.AspNetCore.LocalizedRouting
{
    public class Localized
    {
        public string OriginalName { get; set; }
        public List<LocalizedRoute> LocalizerRoutes { get; set; } = new List<LocalizedRoute>();

    }
}
