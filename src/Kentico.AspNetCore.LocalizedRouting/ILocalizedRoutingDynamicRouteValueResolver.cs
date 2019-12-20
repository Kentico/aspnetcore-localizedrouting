using Microsoft.AspNetCore.Routing;

namespace Kentico.AspNetCore.LocalizedRouting
{
    public interface ILocalizedRoutingDynamicRouteValueResolver
    {
        RouteValueDictionary Resolve(RouteValueDictionary values);
    }
}