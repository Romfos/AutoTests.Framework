using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Specflow;
using AutoTests.Framework.Core.Specflow.Utils;
using AutoTests.Framework.PreProcessor;
using AutoTests.Framework.PreProcessor.Roslyn;
using BoDi;
using System.Reflection;
using TechTalk.SpecFlow;
using AutoTests.Framework.Core.Extensions;
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
            var container = ConfigureContainer();
            ConfigurePreProcessor(container);
        }

        private IContainer ConfigureContainer()
        {
            var container = new SpecflowContainer(objectContainer, Assembly.GetExecutingAssembly());
            container.Register<IContainer>(container);
            return container;
        }

        private void ConfigurePreProcessor(IContainer container)
        {
            container.Register<IPreProcessor>(new RoslynPreProcessor());

            var specflowBindingsUtils = container.Resolve<SpecflowBindingsUtils>();
            specflowBindingsUtils.RegisterBindings(typeof(DefaultPreProcessortBindings));
            specflowBindingsUtils.RegisterBindings(typeof(DefaultContractsBindings));
        }
    }
}
