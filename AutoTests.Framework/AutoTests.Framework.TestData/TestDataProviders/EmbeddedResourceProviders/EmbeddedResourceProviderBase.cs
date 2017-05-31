using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.TestData.Entities;

namespace AutoTests.Framework.TestData.TestDataProviders.EmbeddedResourceProviders
{
    public abstract class EmbeddedResourceProviderBase : TestDataProvider
    {
        protected Dictionary<string, string> Resources { get; }

        protected EmbeddedResourceProviderBase()
        {
            Resources = LoadResources();
        }
        
        private Dictionary<string, string> LoadResources()
        {
            return GetResourceLocations()
                .SelectMany(LoadResources)
                .ToDictionary(x => x.Key, x=> x.Value);
        }

        public override object GetResoruce(string name)
        {
            return Resources.ContainsKey(name) ? Resources[name] : null;
        }

        protected abstract IEnumerable<EmbeddedResourceLocation> GetResourceLocations();

        protected abstract IEnumerable<KeyValuePair<string, string>> LoadResources(EmbeddedResourceLocation location);
    }
}