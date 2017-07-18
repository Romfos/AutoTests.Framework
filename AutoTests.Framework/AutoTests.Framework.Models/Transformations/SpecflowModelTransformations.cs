using System;
using System.Collections.Generic;
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
            return modelTransformations.Transform<T>(TransformHorizonalTable(table));
        }

        [StepArgumentTransformation]
        public IEnumerable<T> TransformToEnumerable(Table table)
        {
            return TransformVerticalTable(table).Select(x => modelTransformations.Transform<T>(x));
        }

        [StepArgumentTransformation]
        public T[] TransformToArray(Table table)
        {
            return TransformToEnumerable(table).ToArray();
        }

        [StepArgumentTransformation]
        public List<T> TransformToList(Table table)
        {
            return TransformToEnumerable(table).ToList();
        }

        private Prototype[] TransformHorizonalTable(Table table)
        {
            CheckHorizonalTableConstraints(table);

            var containValue = table.ContainsColumn("Value");
            var containAttributes = table.ContainsColumn("Attributes");

            var prototypes = table.Rows.Select(x => new Prototype(
                x["Name"],
                containValue ? x["Value"] : null,
                containAttributes ? x["Attributes"] : null));

            return prototypes.ToArray();
        }
        
        private void CheckHorizonalTableConstraints(Table table)
        {
            if (!table.ContainsColumn("Name"))
            {
                throw new TransformationException("Table should contain 'Name' column");
            }

            string[] columns =
            {
                "Name",
                "Value",
                "Attributes"
            };

            if (!table.Header.All(columns.Contains))
            {
                throw new TransformationException("Table contains unsupported columns");
            }
        }

        private IEnumerable<Prototype[]> TransformVerticalTable(Table table)
        {
            return table.Rows.Select(x => x.Select(y => new Prototype(y.Key, y.Value, String.Empty)).ToArray());
        }
    }
}