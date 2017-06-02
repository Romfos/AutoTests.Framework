using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoTests.Tools.Refactroings.Entities;
using AutoTests.Tools.Refactroings.Parsers;
using AutoTests.Tools.Refactroings.Services;
using AutoTests.Tools.Tests.Models;
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

        [TestMethod]
        public void ChangePropertyNameTest()
        {
            stepsServices.ChangePropertyName<RenameModel>("Number", "Id");

            var step1 = stepsServices.FindSteps(x => x.Text == "rename model one").Single().step;
            var step2 = stepsServices.FindSteps(x => x.Text == "rename model two").Single().step;

            Assert.AreEqual("Id", step1.Table.Rows[0].Items[0].Name);
            Assert.AreEqual("Id", step2.Table.Rows[0].Items[0].Name);
            Assert.AreEqual("Id", step2.Table.Rows[1].Items[0].Name);
        }
    }
}