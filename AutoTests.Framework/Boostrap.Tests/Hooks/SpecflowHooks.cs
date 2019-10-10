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
            ConfigurePreProcessor();
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
            objectContainer.RegisterInstanceAs<IPreProcessor>(new RoslynPreProcessor());

            var specflowBindingsUtils = objectContainer.Resolve<SpecflowBindingsUtils>();
            specflowBindingsUtils.RegisterBindings(typeof(DefaultPreProcessortBindings));
            specflowBindingsUtils.RegisterBindings(typeof(DefaultContractsBindings));

            objectContainer.RegisterInstanceAs<IWebDriver>(WebDriverFactory.GetWebDriver());
        }
    }
}
