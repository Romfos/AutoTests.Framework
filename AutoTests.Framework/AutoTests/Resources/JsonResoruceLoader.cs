using System.Collections.Generic;
using System.Reflection;
using AutoTests.Framework.Resources;
using AutoTests.Framework.Resources.Infrastructure;
using AutoTests.Framework.Resources.ResourceLoaders;

namespace AutoTests.Resources
{
    public class JsonResoruceLoader : EmbeddedJsonResourceLoader
    {
        public JsonResoruceLoader(ResourcesDependencies dependencies) : base(dependencies)
        {
        }

        protected override IEnumerable<EmbeddedResourceLocation> GetResoruceLocations()
        {
            yield return new EmbeddedResourceLocation(
                Assembly.GetExecutingAssembly(), "AutoTests.TestData.(.*).json");
        }
    }
}