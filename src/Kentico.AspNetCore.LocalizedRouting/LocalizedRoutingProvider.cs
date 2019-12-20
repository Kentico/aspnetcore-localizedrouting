using Kentico.AspNetCore.LocalizedRouting.Attributes;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kentico.AspNetCore.LocalizedRouting
{
    public partial class LocalizedRouteProvider : LocalizedRoutingProviderBase, ILocalizedRoutingProvider
    {
        public static IEnumerable<Localized> Translations = new List<Localized>();
        private IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public LocalizedRouteProvider(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

 
        public async Task<string> ProvideRouteAsync(string culture, string value, ProvideRouteType type)
        {
            if (!Translations.Any())
            {
                Translations = await GetTranslationsAsync();
            }

            if(type == ProvideRouteType.TranslatedToOriginal)
            {
                return TranslatedToOriginal(culture, value);
            }
            else if(type == ProvideRouteType.OriginalToTranslated)
            {
                return OriginalToTranslated(culture, value);
            }

            return null;
        }


        private string TranslatedToOriginal(string culture, string value)
        {
            var normalizedLang = culture.ToLowerInvariant();
            var normalizedValue = value.ToLowerInvariant();
            var translation = Translations.FirstOrDefault(s => s.LocalizerRoutes.Any(w => w.Localized == value && w.Culture == normalizedLang));
            if (translation != null)
            {
                return translation.OriginalName;
            }

            return null;
        }

        private string OriginalToTranslated(string culture, string value)
        {
            var normalizedLang = culture.ToLowerInvariant();
            var normalizedValue = value.ToLowerInvariant();

            var translation = Translations.FirstOrDefault(s => s.OriginalName == normalizedValue);
            var translated = translation?.LocalizerRoutes.FirstOrDefault(s => s.Culture == normalizedLang);
            if (translated != null)
            {
                return translated.Localized;
            }

            return null;
        }


        protected override async Task<IEnumerable<Localized>> GetTranslationsAsync()
        {
            var actions = _actionDescriptorCollectionProvider.ActionDescriptors.Items
                .Where(s => (s as ControllerActionDescriptor).MethodInfo.GetCustomAttributes(typeof(LocalizedRouteAttribute), true).Any())
                .Select(s => new Localized
                {
                    OriginalName = (s as ControllerActionDescriptor).ActionName.ToLower(),
                    LocalizerRoutes = (s as ControllerActionDescriptor).MethodInfo.GetCustomAttributes(typeof(LocalizedRouteAttribute), true).Select(c => new LocalizedRoute
                    {
                        Culture = (c as LocalizedRouteAttribute).Culture.ToLower(),
                        Localized = (c as LocalizedRouteAttribute).LocalizedRoute.ToLower()
                    }).ToList()
                });

            var controllers = _actionDescriptorCollectionProvider.ActionDescriptors.Items
              .Where(s => (s as ControllerActionDescriptor).ControllerTypeInfo.GetCustomAttributes(typeof(LocalizedRouteAttribute), true).Any())
              .Select(s => new Localized
              {
                  OriginalName = (s as ControllerActionDescriptor).ControllerName.ToLower(),
                  LocalizerRoutes = (s as ControllerActionDescriptor).ControllerTypeInfo.GetCustomAttributes(typeof(LocalizedRouteAttribute), true).Select(c => new LocalizedRoute
                  {
                      Culture = (c as LocalizedRouteAttribute).Culture.ToLower(),
                      Localized = (c as LocalizedRouteAttribute).LocalizedRoute.ToLower()
                  }).ToList()
              }).GroupBy(s => s.OriginalName).Select(s => s.FirstOrDefault());

            return controllers.Concat(actions);
        }
    }
}
