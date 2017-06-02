using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoTests.Tools.Refactroings.Entities;
using Gherkin;
using Gherkin.Ast;
using Examples = AutoTests.Tools.Refactroings.Entities.Examples;
using Scenario = AutoTests.Tools.Refactroings.Entities.Scenario;
using Step = AutoTests.Tools.Refactroings.Entities.Step;

namespace AutoTests.Tools.Refactroings.Parsers
{
    public class FeatureFileParser
    {
        private readonly StepDefinition[] stepDefinitions;
        private readonly Parser parser = new Parser();

        public FeatureFileParser(StepDefinition[] stepDefinitions)
        {
            this.stepDefinitions = stepDefinitions;
        }

        public IEnumerable<FeatureFile> Parse(params DirectoryInfo[] directories)
        {
            return GetFeatureFiles(directories).Select(ParseFeatureFile);
        }

        private IEnumerable<FileInfo> GetFeatureFiles(DirectoryInfo[] directories)
        {
            return directories.SelectMany(x => x.GetFiles("*.feature", SearchOption.AllDirectories));
        }

        private FeatureFile ParseFeatureFile(FileInfo file)
        {
            var featureFile = new FeatureFile();
            featureFile.File = file;
            ParseFeature(featureFile, parser.Parse(file.FullName));
            return featureFile;
        }

        private void ParseFeature(FeatureFile featureFile, GherkinDocument document)
        {
            featureFile.Feature.Tags.AddRange(document.Feature.Tags.Select(x => x.Name));
            featureFile.Feature.Description = document.Feature.Description;
            featureFile.Feature.Name = document.Feature.Name;
            featureFile.Feature.Scenarios.AddRange(PasseScenarios(document.Feature.Children));
        }

        private IEnumerable<Scenario> PasseScenarios(IEnumerable<ScenarioDefinition> sources)
        {
            foreach (var source in sources)
            {
                if (source is Gherkin.Ast.Scenario scenario)
                {
                    yield return ParseScenario(scenario);
                }
                else if (source is ScenarioOutline scenarioOutline)
                {
                    yield return ParseScenarioOutline(scenarioOutline);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        private Scenario ParseScenario(Gherkin.Ast.Scenario source)
        {
            var scenario = new Scenario();
            scenario.Tags.AddRange(source.Tags.Select(x => x.Name));
            scenario.Name = source.Name;
            scenario.Description = source.Description;
            scenario.Steps.AddRange(ParseSteps(source.Steps));
            return scenario;
        }

        private Scenario ParseScenarioOutline(Gherkin.Ast.ScenarioOutline source)
        {
            var scenario = new Scenario();
            scenario.Tags.AddRange(source.Tags.Select(x => x.Name));
            scenario.Name = source.Name;
            scenario.Description = source.Description;
            scenario.Steps.AddRange(ParseSteps(source.Steps));
            scenario.Exampless.AddRange(source.Examples.Select(ParseExample));
            return scenario;
        }

        private IEnumerable<Step> ParseSteps(IEnumerable<Gherkin.Ast.Step> sources)
        {
            var lastStepType = StepType.Given;
            foreach (var source in sources)
            {
                var step = ParseStep(source, lastStepType);
                lastStepType = step.StepType;
                yield return step;
            }
        }

        private Step ParseStep(Gherkin.Ast.Step source, StepType lastStepType)
        {
            var step = new Step();
            step.StepType = ParseStepType(source.Keyword.Trim(), lastStepType);
            step.Text = source.Text.Trim();
            return step;
        }

        private StepType ParseStepType(string keyword, StepType lastStepType)
        {
            switch (keyword)
            {
                case "When":
                    return StepType.When;
                case "Then":
                    return StepType.Then;
                case "Given":
                    return StepType.Given;
                case "And":
                    return lastStepType;
                default:
                    throw new NotImplementedException();
            }
        }
        
        private Examples ParseExample(Gherkin.Ast.Examples source)
        {
            var examples = new Examples();

            var columns = source.TableHeader.Cells.Select(x => x.Value).ToArray();
            examples.Cases.AddRange(source.TableBody.Select(x => ParseExampleCase(columns, x)));

            return examples;
        }

        private ExampleCase ParseExampleCase(string[] headers, Gherkin.Ast.TableRow source)
        {
            var exampleCase = new ExampleCase();
            exampleCase.Cells.AddRange(source.Cells.Select((x, i) => new ExampleCell
            {
                Value = x.Value,
                Column = headers[i]
            }));
            return exampleCase;
        }
    }
}