using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTests.Framework.Tests.UnitTests
{
    [TestClass]
    public class RoslynPreProcessorTests : UnitTestsBase
    {
        [TestMethod]
        public async Task TrivialTest()
        {
            var expected = "Hello World!";
            var actual = await application.Evaluator.Evaluate<string>(expected);
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task RoslynExpressionTest()
        {
            var expression = "@1+2";
            var actual = await application.Evaluator.Evaluate<int>(expression);

            Assert.AreEqual(3, actual);
        }
    }
}