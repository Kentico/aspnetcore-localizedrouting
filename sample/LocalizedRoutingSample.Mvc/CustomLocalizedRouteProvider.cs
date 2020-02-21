using Kentico.AspNetCore.LocalizedRouting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizedRoutingSample.Mvc
{
    public class CustomLocalizedRouteProvider : LocalizedRouteProvider
    {
        public CustomLocalizedRouteProvider(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider) : base(actionDescriptorCollectionProvider)
        {
        }

        protected override async Task<IEnumerable<Localized>> GetTranslationsAsync()
        {
            var routes = new List<Localized>
            {
                new Localized
                {
                    OriginalName = "home", LocalizerRoutes = new List<LocalizedRoute>
                    {
                        new LocalizedRoute {Culture = "en-us", Localized = "home"},
                        new LocalizedRoute {Culture = "cs-cz", Localized = "domu"},
                    }
                },
                new Localized
                {
                    OriginalName = "index", LocalizerRoutes = new List<LocalizedRoute>
                    {
                        new LocalizedRoute {Culture = "en-us", Localized = "index"},
                        new LocalizedRoute {Culture = "cs-cz", Localized = "uvod"},
                    }
                },
                new Localized
                {
                    OriginalName = "privacy", LocalizerRoutes = new List<LocalizedRoute>
                    {
                        new LocalizedRoute {Culture = "en-us", Localized = "privacy"},
                        new LocalizedRoute {Culture = "cs-cz", Localized = "soukromi"},
                    }
                }
            };

            return routes.AsEnumerable();
        }
    }
}
