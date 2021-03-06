[![No Maintenance Intended](https://unmaintained.tech/badge.svg)](http://unmaintained.tech/)
## :warning: Deprecation Notice
> This repository is no longer being maintained. Please use the [AspNetCore.Mvc.Routing.Localization](https://github.com/tomasjurasek/AspNetCore.Mvc.Routing.Localization/) package instead.
<br />

# Kentico AspNetCore LocalizedRouting
![Build status](https://ci.appveyor.com/api/projects/status/mlyakjjap02k6oie?svg=true)
## Introduction
The LocalizedRouting package is the extension for [ASP.NET Core Localization](https://docs.microsoft.com/en-US/aspnet/core/fundamentals/localization?view=aspnetcore-3.1#localization-middleware) which provides you localized routing.

### Example

    yoursite.com/cs-CZ/clanky  
    yoursite.com/en-US/articles

The extension provides you several services:
* **LocalizedRouteAttribute** 
* **ILocalizedRoutingProvider**
* **ILocalizedRoutingDynamicRouteValueResolver**
* **LocalizedRoutingAnchorTagHelper**

## Getting started
This is an extension for [ASP.NET Core Localization](https://docs.microsoft.com/en-US/aspnet/core/fundamentals/localization?view=aspnetcore-3.1#localization-middleware). You need to use [RouteDataRequestCultureProvider](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.localization.routing.routedatarequestcultureprovider?view=aspnetcore-3.1) for your culture provider.

### Setup
You should install [Kentico.AspNetCore.LocalizedRouting](https://www.nuget.org/packages/Kentico.AspNetCore.LocalizedRouting/) with NuGet:  

    Install-Package Kentico.AspNetCore.LocalizedRouting
    
You will need to configure services via IServiceCollection extension method.
```csharp
services.AddLocalizedRouting();
```
You need to create a custom `DynamicRouteValueTransformer` and use `ILocalizedRoutingDynamicRouteValueResolver` service in `TransforAsync` method to resolve the translated route.
```csharp
public class CustomLocalizedRoutingTranslationTransformer : DynamicRouteValueTransformer
{
    private ILocalizedRoutingDynamicRouteValueResolver _localizedRoutingDynamicRouteValueResolver;
    public CustomLocalizedRoutingTranslationTransformer(ILocalizedRoutingDynamicRouteValueResolver localizedRoutingDynamicRouteValueResolver)
    {
        _localizedRoutingDynamicRouteValueResolver = localizedRoutingDynamicRouteValueResolver
    }
    public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
    {
        return await _localizedRoutingDynamicRouteValueResolver.ResolveAsync(values);
    }
}

```
Register this service to DI.
```csharp
services.AddSingleton<CustomLocalizedRoutingTranslationTransformer>();
```

Use `CustomLocalizedRoutingTranslationTransformer` in `MapDynamicControllerRoute`. For correct working, your routing template must contain these parameters - **{culture}/{controller}/{action}**.
```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapDynamicControllerRoute<CustomLocalizedRoutingTranslationTransformer>("{culture}/{controller}/{action}/{id?}");
    endpoints.MapControllerRoute("default", "{culture=en-US}/{controller=Home}/{action=Index}/{id?}");
});
```

Use `LocalizedRouteAttribute` on your controllers and action methods for specifying the translated route.
```csharp
[LocalizedRoute("en-US", "articles")]
[LocalizedRoute("cs-CZ", "clanky")]
public class ArticlesController : Controller
{
    [LocalizedRoute("en-US", "index")]
    [LocalizedRoute("cs-CZ", "uvod")]
    public async Task<IActionResult> Index()
    {
        return View();
    }

}
```

If you need translated links in application, you have to also register `LocalizedRoutingAnchorTagHelper` instead of the default implementation.
```csharp
@addTagHelper *, Kentico.AspNetCore.LocalizedRouting
@removeTagHelper Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper, Microsoft.AspNetCore.Mvc.TagHelpers
```

## Feedback & Contributing
Check out the [contributing](https://github.com/Kentico/aspnetcore-localizedrouting/blob/master/CONTRIBUTING.md) page to see the best places to file issues, start discussions, and begin contributing.

