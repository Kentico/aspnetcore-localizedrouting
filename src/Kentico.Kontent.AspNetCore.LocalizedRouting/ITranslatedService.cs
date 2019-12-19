namespace Kentico.Kontent.AspNetCore.LocalizedRouting
{
    public interface ITranslatedService
    {
        string Resolve(string culture, string value);
        string ResolveLinks(string culture, string value);
    }
}