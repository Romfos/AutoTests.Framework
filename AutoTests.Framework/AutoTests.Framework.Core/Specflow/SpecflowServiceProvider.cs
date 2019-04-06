using BoDi;
using TechTalk.SpecFlow.Bindings;

namespace AutoTests.Framework.Core.Specflow
{
    public class SpecflowServiceProvider : ServiceProvider
    {
        public SpecflowServiceProvider(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public StepArgumentTransformationsService StepArgumentTransformationService =>
            ObjectContainer.Resolve<StepArgumentTransformationsService>();

        public StepDefinitionBindingService StepDefinitionBindingService =>
            ObjectContainer.Resolve<StepDefinitionBindingService>();

        internal IBindingRegistry BindingRegistry => ObjectContainer.Resolve<IBindingRegistry>();

        internal IBindingFactory BindingFactory => ObjectContainer.Resolve<IBindingFactory>();
    }
}