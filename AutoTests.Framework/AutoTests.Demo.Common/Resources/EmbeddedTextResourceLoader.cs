using System.Collections.Generic;
using System.Reflection;
using AutoTests.Framework.TestData;
using AutoTests.Framework.TestData.Entities;
using AutoTests.Framework.TestData.ResourceLoaders;

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