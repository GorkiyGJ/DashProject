using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration.Provider;

namespace Manitou.Data.Provider
{
    public class ManitouProviderCollection : ProviderCollection
    {
        public new ManitouProviderBase this[string name]
        {
            get { return (ManitouProviderBase)base[name]; }
        }

        public void Add(ManitouProviderBase provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (!(provider is ManitouProviderBase))
                throw new ArgumentException("Invalid provider type", "provider");

            base.Add(provider);
        }
    }
}