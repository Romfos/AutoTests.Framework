using System;
using System.Collections.Generic;
using System.Linq;
using AutoTests.Tools.Refactroings.Entities;

namespace AutoTests.Tools.Refactroings.Refactroings
{
    public class StepsRefactroings : Refactroings
    {
        public StepsRefactroings(List<FeatureFile> featureFiles) : base(featureFiles)
        {
        }
        
        public IEnumerable<(FeatureFile featureFile, Scenario scenario, Step step)> Find(
            Func<Step, bool> condition)
        {
            foreach (var featureFile in FeatureFiles)
            {
                foreach (var scenario in featureFile.Feature.Scenarios)
                {
                    foreach (var step in scenario.Steps)
                    {
                        if (condition(step))
                        {
                            yield return (featureFile, scenario, step);
                        }
                    }
                }
            }
        }

        public void Rename(string converterFormatString, StepAttribute oldStepAttribute, StepAttribute newStepAttribute)
        {
            var steps = Find(x => x.StepDefinition.StepAttributes.Contains(oldStepAttribute))
                .Select(x => x.step)
                .ToArray();

            foreach (var step in steps)
            {
                step.Text = string.Format(converterFormatString, step.GetArguments());
            }

            foreach (var step in steps)
            {
                if (step.StepDefinition.StepAttributes.Contains(oldStepAttribute))
                {
                    step.StepDefinition.StepAttributes.Remove(oldStepAttribute);
                    step.StepDefinition.StepAttributes.Add(newStepAttribute);
                }
            }
        }
    }
}