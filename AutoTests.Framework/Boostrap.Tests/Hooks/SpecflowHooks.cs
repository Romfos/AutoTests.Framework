using AutoTests.Framework.Components.Specflow;
using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Specflow;
using AutoTests.Framework.Core.Specflow.Utils;
using AutoTests.Framework.PreProcessor;
using AutoTests.Framework.PreProcessor.Roslyn;
using AutoTests.Framework.PreProcessor.Specflow;
using BoDi;
using System.Reflection;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Boostrap.Tests.Web;
using AutoTests.Framework.Data;
using Microsoft.CodeAnalysis.Scripting;
using AutoTests.Framework.Data.Loaders;

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
            ConfigureContainer();
            ConfigureTestDataHub();
            ConfigurePreProcessor();
            ConfigureContracts();
            ConfigureWebDriver();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            WebDriverFactory.Dispose();
        }

        private void ConfigureContainer()
        {
            var container = new SpecflowContainer(objectContainer, Assembly.GetExecutingAssembly());
            objectContainer.RegisterInstanceAs<IContainer>(container);
        }

        private void ConfigurePreProcessor()
        {
            var dataHub = objectContainer.Resolve<DataHub>();
            var globals = new BoostrapGlobals(dataHub);
            var scriptOptions = ScriptOptions.Default.AddReferences("Microsoft.CSharp");
            var preProcessor = new RoslynPreProcessor(globals, scriptOptions);
            objectContainer.RegisterInstanceAs<IPreProcessor>(preProcessor);

            var specflowBindingsUtils = objectContainer.Resolve<SpecflowBindingsUtils>();
            specflowBindingsUtils.RegisterBindings(typeof(DefaultPreProcessortBindings));
        }

        private void ConfigureTestDataHub()
        {
            var dataHub = objectContainer.Resolve<DataHub>();
            var jsonDataHubLoader = objectContainer.Resolve<JsonDataHubLoader>();

            jsonDataHubLoader.LoadJsonResource(dataHub,
                Assembly.GetExecutingAssembly(),
                "Boostrap.Tests.Data.Common.json");
        }

        private void ConfigureContracts()
        {
            var specflowBindingsUtils = objectContainer.Resolve<SpecflowBindingsUtils>();
            specflowBindingsUtils.RegisterBindings(typeof(DefaultContractsBindings));
        }

        private void ConfigureWebDriver()
        {
            objectContainer.RegisterInstanceAs<IWebDriver>(WebDriverFactory.GetWebDriver());
        }
    }
}
