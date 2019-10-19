using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Specflow.Utils;
using AutoTests.Framework.Core.Extensions;

namespace AutoTests.Framework.PreProcessor.Specflow.Extensions
{
    public static class AutoTestsAppBuilderExtensions
    {
        public static AutoTestsAppBuilder UseDefaultPreProcessortBindings(this AutoTestsAppBuilder autoTestsAppBuilder)
        {
            var specflowBindingsUtils = autoTestsAppBuilder.Container.Resolve<SpecflowBindingsUtils>();
            specflowBindingsUtils.RegisterBindings(typeof(DefaultPreProcessortBindings));
            return autoTestsAppBuilder;
        }
    }
}
