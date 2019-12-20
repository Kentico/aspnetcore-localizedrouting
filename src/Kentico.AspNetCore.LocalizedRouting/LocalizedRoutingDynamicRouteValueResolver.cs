using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kentico.AspNetCore.LocalizedRouting
{
    public class LocalizedRoutingDynamicRouteValueResolver : ILocalizedRoutingDynamicRouteValueResolver
    {
        private readonly ILocalizedRoutingProvider _localizedRoutingProvider;

        public LocalizedRoutingDynamicRouteValueResolver(ILocalizedRoutingProvider localizedRoutingProvider)
        {
            _localizedRoutingProvider = localizedRoutingProvider;
        }
        public RouteValueDictionary Resolve(RouteValueDictionary values)
        {
            if (!values.ContainsKey("culture") || !values.ContainsKey("controller") || !values.ContainsKey("action")) return values;

            var culture = (string)values["culture"];
            var controller = _localizedRoutingProvider.Resolve(culture, (string)values["controller"]);
            if (controller == null) return values;
            values["controller"] = controller;

            var action = _localizedRoutingProvider.Resolve(culture, (string)values["action"]);
            if (action == null) return values;
            values["action"] = action;

            return values;
        }
    }
}
