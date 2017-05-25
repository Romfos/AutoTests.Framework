using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Stores;
using AutoTests.Framework.PreProcessor.Infrastructure;
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

        internal Assembly[] Assemblies => ObjectContainer.Resolve<Assembly[]>();

        internal StoresDependencies Stores => ObjectContainer.Resolve<StoresDependencies>();

        public override void Setup()
        {
        }

        public IEnumerable<Asset> GetAssets()
        {
            return Assemblies
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsSubclassOf(typeof(Asset)))
                .Select(x => (Asset) ObjectContainer.Resolve(x));
        }
    }
}