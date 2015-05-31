using System;
using System.Collections.Specialized;

namespace Manitou.Data.Provider
{
    public abstract class ManitouProviderBase : System.Configuration.Provider.ProviderBase
    {
        protected ManitouProviderBase() 
        { 
        }
        
        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);
        }

        public abstract string ConnectionString { get; }
    }
}