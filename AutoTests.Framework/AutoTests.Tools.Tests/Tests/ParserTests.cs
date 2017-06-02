using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoTests.Tools.Refactroings.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTests.Tools.Tests.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void StepDefinitionParserTest()
        {
            var parser = new StepDefinitionParser();
            var stepDefinitions = parser.Parse(Assembly.GetExecutingAssembly()).ToArray();

            Assert.IsTrue(stepDefinitions.Any(x => x.MethodInfo.Name == "GivenTest"));
        }

        [TestMethod]
        public void FeatureFileParserTest()
        {
            var parser = new StepDefinitionParser();
            var stepDefinitions = parser.Parse(Assembly.GetExecutingAssembly()).ToArray();

            var featureFileParser = new FeatureFileParser(stepDefinitions);
            var featureFiles = featureFileParser.Parse(
                    new DirectoryInfo(Environment.CurrentDirectory + @"..\..\..\"))
                .ToArray();
            
            Assert.IsTrue(featureFiles.Single().Feature.Scenarios.Any(x => x.Name == "scenario1"));
            Assert.IsTrue(featureFiles.Single().Feature.Scenarios.Any(x => x.Name == "scenario2"));
        }
    }
}