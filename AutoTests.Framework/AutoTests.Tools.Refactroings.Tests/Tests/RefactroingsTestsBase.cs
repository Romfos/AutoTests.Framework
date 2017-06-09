using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoTests.Tools.Refactroings.Entities;
using AutoTests.Tools.Refactroings.Infrastructure;
using AutoTests.Tools.Refactroings.Refactroings;

namespace AutoTests.Tools.Refactroings.Tests.Tests
{
    public abstract class RefactroingsTestsBase
    {
        protected List<FeatureFile> FeatureFiles { get; }

        protected StepsRefactroings StepsRefactroings { get; }
        protected ModelRefactroings ModelRefactroings { get; }

        protected RefactroingsTestsBase()
        {
            var parser = new StepDefinitionParser();
            var stepDefinitions = parser.Parse(Assembly.GetExecutingAssembly()).ToArray();

            var featureFileParser = new FeatureFileParser(stepDefinitions);
            var directory = new DirectoryInfo(Environment.CurrentDirectory + @"..\..\..\");

            FeatureFiles = featureFileParser.Parse(directory).ToList();

            StepsRefactroings = new StepsRefactroings(FeatureFiles);
            ModelRefactroings = new ModelRefactroings(FeatureFiles);
        }
    }
}