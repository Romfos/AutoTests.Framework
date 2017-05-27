using System.Collections.Generic;
using System.Reflection;
using AutoTests.Framework.Resources;
using AutoTests.Framework.Resources.Entities;
using AutoTests.Framework.Resources.ResourceLoaders;

namespace AutoTests.Demo.Common.Resources
{
    public class EmbeddedTextResourceLoader : EmbeddedTextResourceLoaderBase
    {
        public EmbeddedTextResourceLoader(ResourcesDependencies dependencies) : base(dependencies)
        {
        }

        protected override IEnumerable<EmbeddedResourceLocation> GetResoruceLocations()
        {
            yield return new EmbeddedResourceLocation(
                Assembly.GetExecutingAssembly(),
                "AutoTests.Demo.Common.TestData.(.*).txt");
        }
    }
}