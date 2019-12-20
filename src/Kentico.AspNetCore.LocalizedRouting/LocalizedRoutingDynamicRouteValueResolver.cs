using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kentico.AspNetCore.LocalizedRouting
{
    public class LocalizedRoutingDynamicRouteValueResolver : ILocalizedRoutingDynamicRouteValueResolver
    {
        private readonly ILocalizedRoutingProvider _localizedRoutingProvider;

        public LocalizedRoutingDynamicRouteValueResolver(ILocalizedRoutingProvider localizedRoutingProvider)
        {
            _localizedRoutingProvider = localizedRoutingProvider;
        }
        public async Task<RouteValueDictionary> ResolveAsync(RouteValueDictionary values)
        {
            if (!values.ContainsKey("culture") || !values.ContainsKey("controller") || !values.ContainsKey("action")) return values;

            var culture = (string)values["culture"];
            var controller = _localizedRoutingProvider.ProvideRouteAsync(culture, (string)values["controller"], ProvideRouteType.TranslatedToOriginal);
            if (controller == null) return values;
            values["controller"] = controller;

            var action = _localizedRoutingProvider.ProvideRouteAsync(culture, (string)values["action"], ProvideRouteType.TranslatedToOriginal);
            if (action == null) return values;
            values["action"] = action;

            return values;
        }
    }
}
