using AutoTests.Framework.Core;
using BootstrapTests.Web;
using TechTalk.SpecFlow;

namespace BootstrapTests.Steps
{
    [Binding]
    public class SpecflowHooks
    {
        private readonly AutoTestsFrameworkBuilder autoTestsFrameworkBuilder;

        public SpecflowHooks(AutoTestsFrameworkBuilder autoTestsFrameworkBuilder)
        {
            this.autoTestsFrameworkBuilder = autoTestsFrameworkBuilder;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            autoTestsFrameworkBuilder
                .RegisterApplicationAssembly<Application>()
                .Build<Application>();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            WebDriverProvider.Stop();
        }
    }
}
