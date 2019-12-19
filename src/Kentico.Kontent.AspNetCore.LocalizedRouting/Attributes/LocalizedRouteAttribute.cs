using System;
using System.Collections.Generic;
using System.Text;

namespace Kentico.Kontent.AspNetCore.LocalizedRouting.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class LocalizedRouteAttribute : Attribute
    {
        public LocalizedRouteAttribute(string culture, string localizedRoute)
        {
            Culture = culture;
            LocalizedRoute = localizedRoute;
        }

        public string Culture { get; }
        public string LocalizedRoute { get; }
    }
}
