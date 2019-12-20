using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kentico.AspNetCore.LocalizedRouting
{
    public abstract class LocalizedRoutingProviderBase
    {
        protected abstract Task<IEnumerable<Localized>> GetTranslationsAsync();
    }
}
