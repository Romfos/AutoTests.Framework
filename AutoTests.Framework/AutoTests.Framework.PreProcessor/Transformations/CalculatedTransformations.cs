using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.Core.Transformations;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.PreProcessor.Transformations
{
    public class CalculatedTransformations : StepArgumentTransformations
    {
        private readonly PreProcessorDependencies dependencies;

        public CalculatedTransformations(PreProcessorDependencies dependencies)
        {
            this.dependencies = dependencies;
        }

        [StepArgumentTransformation]
        public Calculated Transform(string source)
        {
            return new Calculated(dependencies.Compiler, source);
        }

        [StepArgumentTransformation]
        public Dictionary<Calculated, Calculated> Transform(Table table)
        {
            return table.Rows.ToDictionary(x => Transform(x["Name"]), x => Transform(x["Value"]));
        }
    }
}