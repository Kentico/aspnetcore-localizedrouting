using System;
using System.Collections.Generic;
using System.Text;

namespace Kentico.Kontent.AspNetCore.LocalizedRouting
{
    public abstract class TranslatedRouteServiceBase
    {
        protected abstract IEnumerable<Localized> GetTranslationsData();
    }
}
