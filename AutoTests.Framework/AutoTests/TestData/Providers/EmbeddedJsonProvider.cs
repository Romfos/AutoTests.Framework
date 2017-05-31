using System.Collections.Generic;
using System.Reflection;
using AutoTests.Framework.TestData.Entities;
using AutoTests.Framework.TestData.TestDataProviders;

namespace AutoTests.TestData.Providers
{
    public class EmbeddedJsonProvider : EmbeddedJsonProviderBase
    {
        public EmbeddedJsonProvider(Application application)
            : base(application.TestData)
        {
        }
        
        protected override IEnumerable<EmbeddedResourceLocation> GetResoruceLocations()
        {
            yield return new EmbeddedResourceLocation(
                Assembly.GetExecutingAssembly(), "AutoTests.TestData.Resources.(.*).json");
        }
    }
}