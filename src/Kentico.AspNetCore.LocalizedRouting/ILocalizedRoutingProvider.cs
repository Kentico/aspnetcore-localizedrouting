using System.Threading.Tasks;
using static Kentico.AspNetCore.LocalizedRouting.LocalizedRouteProvider;

namespace Kentico.AspNetCore.LocalizedRouting
{
    public interface ILocalizedRoutingProvider
    {
        Task<string> ProvideRouteAsync(string culture, string value, string controllerName, ProvideRouteType type);
    }
}