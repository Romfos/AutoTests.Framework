using AutoTests.Framework.PreProcessor.Roslyn;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace AutoTests.Framework.Tests.UnitTests
{
    [TestClass]
    public class PreProcessorTests : UnitTestsBase
    {
        [TestMethod]
        public async Task RoslynExpressionTest()
        {
            var preProcessor = new RoslynPreProcessor();

            var result = await preProcessor.ExecuteAsync<int>("@1 + 2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public async Task ConstantStringTest()
        {
            var preProcessor = new RoslynPreProcessor();

            var result = await preProcessor.ExecuteAsync<int>("1");

            Assert.AreEqual(1, result);
        }
    }
}
