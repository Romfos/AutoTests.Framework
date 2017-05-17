﻿using System.Collections.Generic;
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
            if (!table.ContainsColumn("Name"))
            {
                throw new TransformationException("Table should contain 'Name' column");
            }
            if (!table.ContainsColumn("Value"))
            {
                throw new TransformationException("Table should contain 'Value' column");
            }
            if (table.Header.Any(x => x != "Name" || x != "Value"))
            {
                throw new TransformationException("Table contian unavailable columns");
            }
            return table.Rows.Select(x => new Prototype(x["Name"], x["Value"])).ToArray();
        }

        private IEnumerable<Prototype[]> TransformVerticalTable(Table table)
        {
            return table.Rows.Select(x => x.Select(y => new Prototype(y.Key, y.Value)).ToArray());
        }
    }
}