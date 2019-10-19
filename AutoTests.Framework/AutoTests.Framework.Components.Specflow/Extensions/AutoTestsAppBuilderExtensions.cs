using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Extensions;
using AutoTests.Framework.Core.Specflow.Utils;

namespace AutoTests.Framework.Components.Specflow.Extensions
{
    public static class AutoTestsAppBuilderExtensions
    {
        public static AutoTestsAppBuilder UseDefaultContractsBindings(this AutoTestsAppBuilder autoTestsAppBuilder)
        {
            var specflowBindingsUtils = autoTestsAppBuilder.Container.Resolve<SpecflowBindingsUtils>();
            specflowBindingsUtils.RegisterBindings(typeof(DefaultContractsBindings));
            return autoTestsAppBuilder;
        }
    }
}
