using AutoTests.Framework.Core;
using AutoTests.Framework.PreProcessor.Roslyn;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Tests.Steps
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
                .UseRoslynPreProcessor()
                .Build<Application>();
        }
    }
}