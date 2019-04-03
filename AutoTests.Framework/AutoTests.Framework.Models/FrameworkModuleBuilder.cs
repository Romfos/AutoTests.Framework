using AutoTests.Framework.Core;
using AutoTests.Framework.Models.Transformations;

namespace AutoTests.Framework.Models
{
    public static class FrameworkModuleBuilder
    {
        public static AutoTestsFrameworkBuilder UseModelStepTransformations(
            this AutoTestsFrameworkBuilder autoTestsFrameworkBuilder)
        {
            return autoTestsFrameworkBuilder.Use(x =>
                x.Resolve<ModelTransformationsServiceProvider>()
                    .ModelStepArgumentTransformationsService.RegisterStepArgumentTransformations());
        }
    }
}