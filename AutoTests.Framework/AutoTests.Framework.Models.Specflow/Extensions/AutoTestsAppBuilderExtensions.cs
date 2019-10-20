using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Specflow.Utils;
using AutoTests.Framework.Core.Extensions;
using System.Linq;

namespace AutoTests.Framework.Models.Specflow.Extensions
{
    public static class AutoTestsAppBuilderExtensions
    {
        public static AutoTestsAppBuilder UseModelTransformations(this AutoTestsAppBuilder autoTestsAppBuilder)
        {
            var specflowBindingsUtils = autoTestsAppBuilder.Container.Resolve<SpecflowBindingsUtils>();
            var modelTypes = autoTestsAppBuilder.Container.GetSubTypes(typeof(Model));
            var bindingClassTypes = modelTypes.Select(x => typeof(ModelTransformationBindings<>).MakeGenericType(x));
            foreach(var bindingClassType in bindingClassTypes)
            {
                specflowBindingsUtils.RegisterBindings(bindingClassType);
            }
            return autoTestsAppBuilder;
        }
    }
}
