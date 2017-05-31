using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.TestData.Entities;

namespace AutoTests.Framework.TestData.TestDataProviders.EmbeddedResourceProviders
{
    public abstract class EmbeddedResourceProviderBase : TestDataProvider
    {
        private Dictionary<string, string> resources;
        
        public override void LoadResoruces()
        {
            resources = GetResourceLocations()
                .SelectMany(ParseResource)
                .ToDictionary(x => x.Key, x => x.Value);
        }

        public override object GetResoruce(string name)
        {
            return resources.ContainsKey(name) ? resources[name] : null;
        }

        protected abstract IEnumerable<EmbeddedResourceLocation> GetResourceLocations();

        protected abstract IEnumerable<KeyValuePair<string, string>> ParseResource(EmbeddedResourceLocation location);
    }
}