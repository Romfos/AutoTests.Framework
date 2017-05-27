using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Utils;
using AutoTests.Framework.Resources.ResourceLoaders;
using BoDi;

namespace AutoTests.Framework.Resources
{
    public class ResourcesDependencies : Dependencies
    {
        public ResourcesDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public ResourceMananger Mananger => ObjectContainer.Resolve<ResourceMananger>();

        internal UtilsDependencies Utils => ObjectContainer.Resolve<UtilsDependencies>();

        internal IEnumerable<ResourceLoader> GetResourceLoaders()
        {
            return Core.Assemblies
                .SelectMany(x => x.GetTypes())
                .Where(x => !x.IsGenericType && !x.IsAbstract && x.IsSubclassOf(typeof(ResourceLoader)))
                .Select(x => (ResourceLoader) ObjectContainer.Resolve(x));
        }

        protected override void RegisterCustomTypes()
        {
            Utils.Register();
        }

        protected override void ConfigureDependencies()
        {
            Utils.Configure();
        }
    }
}