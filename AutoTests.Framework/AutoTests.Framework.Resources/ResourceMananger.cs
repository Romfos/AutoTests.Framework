using System.Linq;
using AutoTests.Framework.Core.Extensions;
using AutoTests.Framework.Resources.ResourceLoaders;

namespace AutoTests.Framework.Resources
{
    public class ResourceMananger
    {
        private readonly ResourceLoader[] resourceLoaders;

        public ResourceMananger(ResourcesDependencies dependencies)
        {
            resourceLoaders = dependencies.GetResourceLoaders().ToArray();
        }

        public object GetResource(string name)
        {
            return resourceLoaders.Select(x => x.GetResoruce(name)).FirstNotNull();
        }
    }
}