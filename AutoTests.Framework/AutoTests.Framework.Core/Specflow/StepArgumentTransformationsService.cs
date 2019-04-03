using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings.Reflection;

namespace AutoTests.Framework.Core.Specflow
{
    public class StepArgumentTransformationsService
    {
        private readonly SpecflowServiceProvider serviceProvider;

        public StepArgumentTransformationsService(SpecflowServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void RegisterStepArgumentTransformations(object transformations)
        {
            foreach (var methodInfo in GetStepArgumentTransformationMethods(transformations))
            {
                var stepArgumentTransformationAttribute = methodInfo
                    .GetCustomAttributes<StepArgumentTransformationAttribute>().Single();

                var stepArgumentTransformationBinding = serviceProvider.BindingFactory
                    .CreateStepArgumentTransformation(stepArgumentTransformationAttribute.Regex,
                    new RuntimeBindingMethod(methodInfo));

                serviceProvider.BindingRegistry.RegisterStepArgumentTransformationBinding(
                    stepArgumentTransformationBinding);
            }
        }

        private IEnumerable<MethodInfo> GetStepArgumentTransformationMethods(object transformations)
        {
            return transformations.GetType().GetMethods()
                .Where(x => x.GetCustomAttributes<StepArgumentTransformationAttribute>().Any());
        }
    }
}