using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AutoTests.Framework.TestData.Entities;
using Newtonsoft.Json.Linq;

namespace AutoTests.Framework.TestData.TestDataProviders
{
    public abstract class EmbeddedJsonProviderBase : TestDataProvider
    {
        private readonly TestDataDependencies dependencies;

        protected Dictionary<string, string> Resources { get; }

        protected EmbeddedJsonProviderBase(TestDataDependencies dependencies)
        {
            this.dependencies = dependencies;

            Resources = LoadResources().ToDictionary(x => x.Key, x => x.Value);
        }

        public override object GetResoruce(string name)
        {
            return Resources.ContainsKey(name) ? Resources[name] : null;
        }

        protected abstract IEnumerable<EmbeddedResourceLocation> GetResoruceLocations();

        private IEnumerable<KeyValuePair<string, string>> LoadResources()
        {
            return GetResoruceLocations().SelectMany(LoadResources);
        }

        private IEnumerable<KeyValuePair<string, string>> LoadResources(EmbeddedResourceLocation location)
        {
            var regex = new Regex(location.Regex);

            return location.Assembly.GetManifestResourceNames()
                .Where(x => regex.IsMatch(x))
                .SelectMany(x => LoadResources(dependencies.Utils.Resources.GetJsonResource(location.Assembly, x),
                    regex.Match(x).Groups[1].Value));
        }

        private IEnumerable<KeyValuePair<string, string>> LoadResources(JObject jObject, string resourceName)
        {
            return jObject.Descendants()
                .OfType<JValue>()
                .Select(x => new KeyValuePair<string, string>($"{resourceName}.{x.Path}", x.ToString()));
        }
    }
}