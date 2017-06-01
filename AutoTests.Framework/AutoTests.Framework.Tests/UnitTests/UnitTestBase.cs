using AutoTests.Framework.Core.Steps;
using BoDi;
using TechTalk.SpecFlow.Bindings;

namespace AutoTests.Framework.Tests.UnitTests
{
    public abstract class UnitTestBase
    {
        protected Application Application { get; }
        protected Assert Assert { get; }

        protected UnitTestBase()
        {
            Application = CreateApplication();
            Application.Register();
            Application.Configure();

            Assert = Application.Steps.Assert;
        }

        private Application CreateApplication()
        {
            var container = new ObjectContainer();
            container.RegisterTypeAs<IBindingFactory>(typeof(BindingFactory));
            container.RegisterTypeAs<IBindingRegistry>(typeof(BindingRegistry));
            container.RegisterTypeAs<IStepDefinitionRegexCalculator>(typeof(StepDefinitionRegexCalculator));
            return container.Resolve<Application>();
        }
    }
}