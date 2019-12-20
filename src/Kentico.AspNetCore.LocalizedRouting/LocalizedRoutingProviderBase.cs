using System;
using System.Collections.Generic;
using System.Text;

namespace Kentico.AspNetCore.LocalizedRouting
{
    public abstract class LocalizedRoutingProviderBase
    {
        protected abstract IEnumerable<Localized> GetTranslations();
    }
}
