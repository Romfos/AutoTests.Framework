using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AutoTests.Framework.TestData.Entities;
using Newtonsoft.Json.Linq;

namespace AutoTests.Framework.TestData.TestDataProviders.EmbeddedResourceProviders
{
    public abstract class EmbeddedJsonProviderBase : EmbeddedResourceProviderBase
    {
        private readonly TestDataDependencies dependencies;

        protected EmbeddedJsonProviderBase(TestDataDependencies dependencies)
        {
            this.dependencies = dependencies;
        }

        protected override IEnumerable<KeyValuePair<string, string>> LoadResources(EmbeddedResourceLocation location)
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