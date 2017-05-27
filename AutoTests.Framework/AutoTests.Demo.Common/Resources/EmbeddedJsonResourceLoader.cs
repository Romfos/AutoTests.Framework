using System.Collections.Generic;
using System.Reflection;
using AutoTests.Framework.TestData.Entities;
using AutoTests.Framework.TestData.ResourceLoaders;

namespace AutoTests.Demo.Common.Resources
{
    public class EmbeddedJsonResourceLoader : EmbeddedJsonResourceLoaderBase
    {
        public EmbeddedJsonResourceLoader(Application application)
            : base(application.Resources)
        {
        }

        protected override IEnumerable<EmbeddedResourceLocation> GetResoruceLocations()
        {
            yield return new EmbeddedResourceLocation(
                Assembly.GetExecutingAssembly(),
                "AutoTests.Demo.Common.TestData.(.*).json");
        }
    }
}