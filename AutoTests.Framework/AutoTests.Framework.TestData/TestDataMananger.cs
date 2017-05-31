using System.Linq;
using AutoTests.Framework.Core.Extensions;
using AutoTests.Framework.TestData.TestDataProviders;

namespace AutoTests.Framework.TestData
{
    public class TestDataMananger
    {
        private readonly TestDataProvider[] testDataProviders;

        public TestDataMananger(TestDataDependencies dependencies)
        {
            testDataProviders = dependencies.GetTestDataProviders().ToArray();

            foreach (var testDataProvider in testDataProviders)
            {
                testDataProvider.LoadResoruces();
            }
        }

        public object GetResource(string name)
        {
            return testDataProviders.Select(x => x.GetResoruce(name)).FirstNotNull();
        }
    }
}