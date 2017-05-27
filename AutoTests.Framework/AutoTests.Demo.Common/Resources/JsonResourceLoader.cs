using System.Collections.Generic;
using System.Reflection;
using AutoTests.Framework.Resources.Entities;
using AutoTests.Framework.Resources.ResourceLoaders;

namespace AutoTests.Demo.Common.Resources
{
    public class JsonResourceLoader : EmbeddedJsonResourceLoaderBase
    {
        public JsonResourceLoader(Application application)
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