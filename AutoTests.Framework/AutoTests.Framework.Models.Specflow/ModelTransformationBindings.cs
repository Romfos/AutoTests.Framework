using AutoTests.Framework.Core;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Models.Specflow
{
    public class ModelTransformationBindings
    {
        private readonly IContainer container;
        private readonly ModelComparator comparator;

        public ModelTransformationBindings(IContainer container, ModelComparator comparator)
        {
            this.container = container;
            this.comparator = comparator;
        }

        [StepArgumentTransformation]
        public ModelExpression GetModelExpression(Table table)
        {
            return new ModelExpression(container, comparator, table);
        }
    }
}
