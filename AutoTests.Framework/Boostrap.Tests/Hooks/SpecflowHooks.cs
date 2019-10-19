using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Specflow;
using BoDi;
using System.Reflection;
using TechTalk.SpecFlow;
using Boostrap.Tests.Web;
using Microsoft.CodeAnalysis.Scripting;
using AutoTests.Framework.PreProcessor.Roslyn.Extensions;
using AutoTests.Framework.PreProcessor.Specflow.Extensions;
using AutoTests.Framework.Components.Specflow.Extensions;
using AutoTests.Framework.Data.Extensions;

namespace Boostrap.Tests.Hooks
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
                .UseRoslynPreProcessor<BoostrapGlobals>(ScriptOptions.Default.AddReferences("Microsoft.CSharp"))
                .UseDefaultPreProcessortBindings()
                .UseDefaultContractsBindings()
                .UseJsonResource(Assembly.GetExecutingAssembly(), "Boostrap.Tests.Data.Common.json");

            container.Register(WebDriverFactory.GetWebDriver());
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            WebDriverFactory.Start();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            WebDriverFactory.Stop();
        }
    }
}
