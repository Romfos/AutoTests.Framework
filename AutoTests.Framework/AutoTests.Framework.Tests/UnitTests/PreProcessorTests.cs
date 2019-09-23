using AutoTests.Framework.PreProcessor.Roslyn;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace AutoTests.Framework.Tests.UnitTests
{
    [TestClass]
    public class PreProcessorTests : UnitTestsBase
    {
        [TestMethod]
        public async Task RoslynPreProcessorTest()
        {
            var preProcessor = new RoslynPreProcessor();

            var result = await preProcessor.ExecuteAsync<int>("1 + 2");

            Assert.AreEqual(3, result);
        }
    }
}
