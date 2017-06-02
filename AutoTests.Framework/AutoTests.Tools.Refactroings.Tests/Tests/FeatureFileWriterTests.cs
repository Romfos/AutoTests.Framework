using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoTests.Tools.Refactroings.Entities;
using AutoTests.Tools.Refactroings.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTests.Tools.Tests.Tests
{
    [TestClass]
    public class FeatureFileWriterTests
    {
        private readonly DirectoryInfo directory = new DirectoryInfo(Environment.CurrentDirectory + @"..\..\..\");
        private readonly FeatureFile[] featureFiles;
        private readonly FeatureFileWriter featureFileWriter;

        public FeatureFileWriterTests()
        {
            var parser = new StepDefinitionParser();
            var stepDefinitions = parser.Parse(Assembly.GetExecutingAssembly()).ToArray();

            var featureFileParser = new FeatureFileParser(stepDefinitions);
            featureFiles = featureFileParser.Parse(directory).ToArray();

            featureFileWriter = new FeatureFileWriter();
        }

        [TestMethod]
        public void FeatureFileWriterTest()
        {
            var exepcted = new Dictionary<string, string>();

            foreach (var file in directory.GetFiles("*.feature").Select(x => x.FullName))
            {
                exepcted.Add(file, File.ReadAllText(file));
            }

            featureFileWriter.Write(featureFiles);

            foreach (var file in directory.GetFiles("*.feature").Select(x => x.FullName))
            {
                Assert.AreEqual(exepcted[file], File.ReadAllText(file));
            }
        }
    }
}