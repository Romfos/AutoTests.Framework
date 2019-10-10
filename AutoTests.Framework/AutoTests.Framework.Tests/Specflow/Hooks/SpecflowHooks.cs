using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Specflow;
using AutoTests.Framework.Core.Specflow.Utils;
using AutoTests.Framework.PreProcessor;
using AutoTests.Framework.PreProcessor.Roslyn;
using BoDi;
using System.Reflection;
using TechTalk.SpecFlow;
using AutoTests.Framework.PreProcessor.Specflow;
using AutoTests.Framework.Components.Specflow;

namespace AutoTests.Framework.Tests.Specflow.Hooks
{
    [Binding]
    public class SpecflowHooks
    {
        private readonly IObjectContainer objectContainer;

        public SpecflowHooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ConfigureContainer();
            ConfigurePreProcessor();
        }

        private void ConfigureContainer()
        {
            var container = new SpecflowContainer(objectContainer, Assembly.GetExecutingAssembly());
            objectContainer.RegisterInstanceAs<IContainer>(container);
        }

        private void ConfigurePreProcessor()
        {
            objectContainer.RegisterInstanceAs<IPreProcessor>(new RoslynPreProcessor());

            var specflowBindingsUtils = objectContainer.Resolve<SpecflowBindingsUtils>();
            specflowBindingsUtils.RegisterBindings(typeof(DefaultPreProcessortBindings));
            specflowBindingsUtils.RegisterBindings(typeof(DefaultContractsBindings));
        }
    }
}
