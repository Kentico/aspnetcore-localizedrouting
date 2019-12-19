using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kentico.Kontent.AspNetCore.LocalizedRouting.Extensions
{
    public static class ServiceCollectionExtensions
    {
        
        public static void AddLocalizedRouting(this IServiceCollection services)
        {
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<ITranslatedService, TranslatedService>();

        }
    }
}
