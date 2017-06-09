using System.Collections.Generic;
using System.Linq;
using AutoTests.Tools.Refactroings.Entities;

namespace AutoTests.Tools.Refactroings.Refactroings
{
    public class ModelRefactroings : Refactroings
    {
        private readonly StepsRefactroings stepsRefactroings;

        public ModelRefactroings(List<FeatureFile> featureFiles) : base(featureFiles)
        {
            stepsRefactroings = new StepsRefactroings(featureFiles);
        }
        
        public void ChangePropertyName<T>(string oldName, string newName)
        {
            bool CheckArgumenyType(Step step)
            {
                return step.IsArgumentType<T>()
                       || step.IsArgumentType<IEnumerable<T>>()
                       || step.IsArgumentType<T[]>()
                       || step.IsArgumentType<List<T>>();
            }

            foreach (var step in stepsRefactroings.Find(CheckArgumenyType).Select(x => x.step))
            {
                foreach (var row in step.Table.Rows)
                {
                    row.GetItemByName(oldName).Name = newName;
                }
            }
        }
    }
}