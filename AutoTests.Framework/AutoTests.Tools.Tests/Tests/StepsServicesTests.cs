using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoTests.Tools.Refactroings.Entities;
using AutoTests.Tools.Refactroings.Parsers;
using AutoTests.Tools.Refactroings.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTests.Tools.Tests.Tests
{
    [TestClass]
    public class StepsServicesTests
    {
        private readonly FeatureFile[] featureFiles;
        private readonly StepsServices stepsServices;

        public StepsServicesTests()
        {
            var parser = new StepDefinitionParser();
            var stepDefinitions = parser.Parse(Assembly.GetExecutingAssembly()).ToArray();

            var featureFileParser = new FeatureFileParser(stepDefinitions);
            var directory = new DirectoryInfo(Environment.CurrentDirectory + @"..\..\..\");
            featureFiles = featureFileParser.Parse(directory).ToArray();

            stepsServices = new StepsServices(featureFiles);
        }
        
        [TestMethod]
        public void FindStepsTest()
        {
            var steps = stepsServices.FindSteps(x => x.Text == "test").ToArray();

            Assert.AreEqual(2, steps.Length);
        }
    }
}