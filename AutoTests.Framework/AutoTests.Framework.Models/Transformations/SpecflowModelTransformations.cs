using System.Linq;
using AutoTests.Framework.Core.Transformations;
using AutoTests.Framework.Models.Exceptions;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Models.Transformations
{
    public class SpecflowModelTransformations<T> : StepArgumentTransformations
        where T : Model, new()
    {
        private readonly ModelTransformations modelTransformations;

        public SpecflowModelTransformations(ModelsDependencies dependencies)
        {
            modelTransformations = dependencies.ModelTransformations;
        }

        [StepArgumentTransformation]
        public T Transform(Table table)
        {
            return modelTransformations.Transform<T>(TransformTable(table));
        }

        private Prototype[] TransformTable(Table table)
        {
            if (!table.ContainsColumn("Name"))
            {
                throw new TransformationException("Table should contain 'Name' column");
            }
            if (!table.ContainsColumn("Value"))
            {
                throw new TransformationException("Table should contain 'Value' column");
            }
            return table.Rows.Select(x => new Prototype(x["Name"], x["Value"])).ToArray();
        }
    }
}