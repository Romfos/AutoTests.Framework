using System.Collections.Generic;
using System.Reflection;
using AutoTests.Framework.TestData.Entities;
using AutoTests.Framework.TestData.TestDataProviders.EmbeddedResourceProviders;

namespace AutoTests.Framework.Tests.TestData.Providers
{
    public class EmbeddedJsonProvider : EmbeddedJsonProviderBase
    {
        public EmbeddedJsonProvider(Application application)
            : base(application.TestData)
        {
        }

        protected override IEnumerable<EmbeddedResourceLocation> GetResourceLocations()
        {
            yield return new EmbeddedResourceLocation(
                Assembly.GetExecutingAssembly(),
                "AutoTests.Framework.Tests.TestData.Resources.(.*).json");
        }
    }
}