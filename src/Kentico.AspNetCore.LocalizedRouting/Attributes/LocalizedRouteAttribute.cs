using System;
using System.Collections.Generic;
using System.Text;

namespace Kentico.AspNetCore.LocalizedRouting.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
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
