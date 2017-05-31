using System.Collections.Generic;
using System.Reflection;
using AutoTests.Framework.TestData;
using AutoTests.Framework.TestData.Entities;
using AutoTests.Framework.TestData.TestDataProviders;
using AutoTests.Framework.TestData.TestDataProviders.EmbeddedResourceProviders;

namespace AutoTests.Demo.Common.TestData.Providers
{
    public class EmbeddedTextProvider : EmbeddedTextProviderBase
    {
        public EmbeddedTextProvider(TestDataDependencies dependencies) : base(dependencies)
        {
        }

        protected override IEnumerable<EmbeddedResourceLocation> GetResourceLocations()
        {
            yield return new EmbeddedResourceLocation(
                Assembly.GetExecutingAssembly(),
                "AutoTests.Demo.Common.TestData.Resources.(.*).txt");
        }
    }
}