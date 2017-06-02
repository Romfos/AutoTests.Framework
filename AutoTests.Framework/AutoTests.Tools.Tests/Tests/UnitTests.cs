using System.Linq;
using System.Reflection;
using AutoTests.Tools.Refactroings.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTests.Tools.Tests.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void StepDefinitionParserTest()
        {
            var parser = new StepDefinitionParser();
            var stepDefinitions = parser.Parse(Assembly.GetExecutingAssembly()).ToArray();

            Assert.AreEqual(3, stepDefinitions.Length);
        }
    }
}