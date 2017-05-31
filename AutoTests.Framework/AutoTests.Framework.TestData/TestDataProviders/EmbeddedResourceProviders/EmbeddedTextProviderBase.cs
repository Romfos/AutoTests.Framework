using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AutoTests.Framework.TestData.Entities;

namespace AutoTests.Framework.TestData.TestDataProviders.EmbeddedResourceProviders
{
    public abstract class EmbeddedTextProviderBase : EmbeddedResourceProviderBase
    {
        private readonly TestDataDependencies dependencies;

        protected EmbeddedTextProviderBase(TestDataDependencies dependencies)
        {
            this.dependencies = dependencies;
        }

        protected override IEnumerable<KeyValuePair<string, string>> LoadResources(EmbeddedResourceLocation location)
        {
            var regex = new Regex(location.Regex);

            return location.Assembly.GetManifestResourceNames()
                .Where(x => regex.IsMatch(x))
                .Select(x => new KeyValuePair<string, string>(regex.Match(x).Groups[1].Value,
                    dependencies.Utils.Resources.GetTextResource(location.Assembly, x)));
        }
    }
}