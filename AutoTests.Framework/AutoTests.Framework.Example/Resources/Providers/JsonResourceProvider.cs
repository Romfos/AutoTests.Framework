using System.Collections.Generic;
using System.Reflection;
using AutoTests.Framework.TestData;
using AutoTests.Framework.TestData.Entities;
using AutoTests.Framework.TestData.TestDataProviders.EmbeddedResourceProviders;

namespace AutoTests.Framework.Example.Resources.Providers
{
    public class JsonResourceProvider : EmbeddedJsonProviderBase
    {
        public JsonResourceProvider(TestDataDependencies dependencies) : base(dependencies)
        {
        }

        protected override IEnumerable<EmbeddedResourceLocation> GetResourceLocations()
        {
            yield return new EmbeddedResourceLocation(
                Assembly.GetExecutingAssembly(),
                "AutoTests.Framework.Example.Resources.Assets.(.*).json");
        }
    }
}