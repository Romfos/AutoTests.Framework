using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Utils;
using AutoTests.Framework.TestData.TestDataProviders;
using BoDi;

namespace AutoTests.Framework.TestData
{
    public class TestDataDependencies : Dependencies
    {
        public TestDataDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public TestDataMananger Mananger => ObjectContainer.Resolve<TestDataMananger>();

        internal UtilsDependencies Utils => ObjectContainer.Resolve<UtilsDependencies>();

        internal IEnumerable<TestDataProvider> GetResourceLoaders()
        {
            return Core.Assemblies
                .SelectMany(x => x.GetTypes())
                .Where(x => !x.IsGenericType && !x.IsAbstract && x.IsSubclassOf(typeof(TestDataProvider)))
                .Select(x => (TestDataProvider) ObjectContainer.Resolve(x));
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