using System;
using System.Collections.Generic;
using System.Linq;
using AutoTests.Tools.Refactroings.Entities;

namespace AutoTests.Tools.Refactroings.Services
{
    public class StepsServices
    {
        private readonly FeatureFile[] featureFiles;

        public StepsServices(FeatureFile[] featureFiles)
        {
            this.featureFiles = featureFiles;
        }

        public IEnumerable<(FeatureFile featureFile, Scenario scenario, Step step)> FindSteps(Func<Step, bool> condition)
        {
            foreach (var featureFile in featureFiles)
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

        public void ChangePropertyName<T>(string oldName, string newName)
        {
            foreach (var step in FindSteps(x => x.IsArgumentType<T>()).Select(x => x.step))
            {
                foreach (var row in step.Table.Rows)
                {
                    row.GetItemByName(oldName).Name = newName;
                }
            }
        }
    }
}