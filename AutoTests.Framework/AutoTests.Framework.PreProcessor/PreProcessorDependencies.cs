using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Stores;
using AutoTests.Framework.PreProcessor.Infrastructure;
using AutoTests.Framework.TestData;
using BoDi;

namespace AutoTests.Framework.PreProcessor
{
    public class PreProcessorDependencies : Dependencies
    {
        public PreProcessorDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public Compiler Compiler => ObjectContainer.Resolve<Compiler>();

        public Options Options => ObjectContainer.Resolve<Options>();
        
        internal StoresDependencies Stores => ObjectContainer.Resolve<StoresDependencies>();

        internal ResourcesDependencies Resources => ObjectContainer.Resolve<ResourcesDependencies>();

        internal new CoreDependencies Core => ObjectContainer.Resolve<CoreDependencies>();

        public IEnumerable<Asset> GetAssets()
        {
            return Core.Assemblies
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsSubclassOf(typeof(Asset)))
                .Select(x => (Asset) ObjectContainer.Resolve(x));
        }

        protected override void RegisterCustomTypes()
        {
            Stores.Register();
            Resources.Register();
        }

        protected override void ConfigureDependencies()
        {
            Stores.Configure();
            Resources.Configure();
        }
    }
}