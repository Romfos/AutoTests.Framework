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

            Assert.AreEqual(4, stepDefinitions.Length);
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

            Assert.AreEqual(2, featureFiles.Single().Feature.Scenarios.Count);
            Assert.AreEqual("scenario1", featureFiles.Single().Feature.Scenarios[0].Name);
            Assert.AreEqual("scenario2", featureFiles.Single().Feature.Scenarios[1].Name);
        }
    }
}