using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace Kentico.AspNetCore.LocalizedRouting
{
    public interface ILocalizedRoutingDynamicRouteValueResolver
    {
        Task<RouteValueDictionary> ResolveAsync(RouteValueDictionary values);
    }
}