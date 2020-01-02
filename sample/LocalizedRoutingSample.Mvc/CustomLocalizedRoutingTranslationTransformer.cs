﻿using Kentico.AspNetCore.LocalizedRouting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizedRoutingSample.Mvc
{
    public class CustomLocalizedRoutingTranslationTransformer : DynamicRouteValueTransformer
    {
        private ILocalizedRoutingDynamicRouteValueResolver _localizedRoutingDynamicRouteValueResolver;
        public CustomLocalizedRoutingTranslationTransformer(ILocalizedRoutingDynamicRouteValueResolver localizedRoutingDynamicRouteValueResolver)
        {
            _localizedRoutingDynamicRouteValueResolver = localizedRoutingDynamicRouteValueResolver;
        }
        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            return await _localizedRoutingDynamicRouteValueResolver.ResolveAsync(values);
        }
    }
}
