using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Specflow;
using AutoTests.Framework.PageObjects.Contracts.Bindings;

namespace AutoTests.Framework.PageObjects.Contracts
{
    public static class FrameworkModuleBuilder
    {
        public static AutoTestsFrameworkBuilder UsePageObjectContacts(
               this AutoTestsFrameworkBuilder autoTestsFrameworkBuilder)
        {
            return autoTestsFrameworkBuilder.Use(x => x.Resolve<SpecflowServiceProvider>()
                    .StepDefinitionBindingService.RegisterStepDefinitions(
                        x.Resolve<ContractDefaultSteps>()));
        }
    }
}
