using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.Bindings.Reflection;

namespace AutoTests.Framework.Core.Specflow
{
    public class StepDefinitionBindingService
    {
        private readonly SpecflowServiceProvider serviceProvider;

        public StepDefinitionBindingService(SpecflowServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void RegisterStepDefinitions(object stepDefinitions)
        {
            foreach(var methodInfo in GetGivenMethods(stepDefinitions))
            {
                var givenAttribute = methodInfo.GetCustomAttributes<GivenAttribute>().Single();
                RegisterStepBinding(StepDefinitionType.Given, givenAttribute.Regex, methodInfo);
            }

            foreach (var methodInfo in GetWhenMethods(stepDefinitions))
            {
                var whenAttribute = methodInfo.GetCustomAttributes<WhenAttribute>().Single();
                RegisterStepBinding(StepDefinitionType.When, whenAttribute.Regex, methodInfo);
            }

            foreach (var methodInfo in GetThenMethods(stepDefinitions))
            {
                var thenAttribute = methodInfo.GetCustomAttributes<ThenAttribute>().Single();
                RegisterStepBinding(StepDefinitionType.Then, thenAttribute.Regex, methodInfo);
            }
        }

        private void RegisterStepBinding(StepDefinitionType stepDefinitionType, string regex, MethodInfo methodInfo)
        {
            var stepArgumentTransformationBinding = serviceProvider
                .BindingFactory.CreateStepBinding(stepDefinitionType,
                    regex, new RuntimeBindingMethod(methodInfo), null);
            serviceProvider.BindingRegistry.RegisterStepDefinitionBinding(stepArgumentTransformationBinding);
        }

        private IEnumerable<MethodInfo> GetGivenMethods(object stepDefinitions)
        {
            return stepDefinitions.GetType().GetMethods()
                .Where(x => x.GetCustomAttributes<GivenAttribute>().Any());
        }

        private IEnumerable<MethodInfo> GetWhenMethods(object stepDefinitions)
        {
            return stepDefinitions.GetType().GetMethods()
                .Where(x => x.GetCustomAttributes<WhenAttribute>().Any());
        }

        private IEnumerable<MethodInfo> GetThenMethods(object stepDefinitions)
        {
            return stepDefinitions.GetType().GetMethods()
                .Where(x => x.GetCustomAttributes<ThenAttribute>().Any());
        }
    }
}
