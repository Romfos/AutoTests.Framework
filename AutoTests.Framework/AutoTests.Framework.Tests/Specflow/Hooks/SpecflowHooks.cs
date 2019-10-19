using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Specflow;
using BoDi;
using System.Reflection;
using TechTalk.SpecFlow;
using AutoTests.Framework.PreProcessor.Roslyn.Extensions;
using AutoTests.Framework.PreProcessor.Specflow.Extensions;
using AutoTests.Framework.Components.Specflow.Extensions;

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
            var container = new SpecflowContainer(objectContainer, Assembly.GetExecutingAssembly());
            
            new AutoTestsAppBuilder(container)
                .UseRoslynPreProcessor()
                .UseDefaultPreProcessortBindings()
                .UseDefaultContractsBindings();
        }
    }
}
