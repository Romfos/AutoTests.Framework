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
            var stepLocations = Find(
                x => x.StepDefinition.StepAttributes.Any(
                    t => t.StepType == oldStepAttribute.StepType && t.Regex.ToString() == oldStepAttribute.Regex.ToString()));

            foreach (var step in stepLocations.Select(x => x.step))
            {
                var attribute = step.StepDefinition.StepAttributes.SingleOrDefault(
                    t => t.StepType == oldStepAttribute.StepType && t.Regex == oldStepAttribute.Regex);

                if (attribute != null)
                {
                    step.StepDefinition.StepAttributes.Remove(attribute);
                    step.StepDefinition.StepAttributes.Add(newStepAttribute);
                }

                step.Text = string.Format(converterFormatString, step.GetArguments());
            }
        }
    }
}