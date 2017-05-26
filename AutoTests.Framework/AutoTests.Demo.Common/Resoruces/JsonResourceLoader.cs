using System.Collections.Generic;
using System.Reflection;
using AutoTests.Framework.Resources.Infrastructure;
using AutoTests.Framework.Resources.ResourceLoaders;

namespace AutoTests.Demo.Common.Resoruces
{
    public class JsonResourceLoader : EmbeddedJsonResourceLoader
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