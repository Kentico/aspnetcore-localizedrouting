namespace Kentico.AspNetCore.LocalizedRouting
{
    public interface ILocalizedRoutingProvider
    {
        string Resolve(string culture, string value);
        string ResolveLinks(string culture, string value);
    }
}