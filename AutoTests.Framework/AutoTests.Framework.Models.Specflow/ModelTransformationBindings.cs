using AutoTests.Framework.Core;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Models.Specflow
{
    public class ModelTransformationBindings
    {
        private readonly IContainer container;

        public ModelTransformationBindings(IContainer container)
        {
            this.container = container;
        }

        [StepArgumentTransformation]
        public ModelExpression GetModelExpression(Table table)
        {
            return new ModelExpression(container, table);
        }
    }
}
