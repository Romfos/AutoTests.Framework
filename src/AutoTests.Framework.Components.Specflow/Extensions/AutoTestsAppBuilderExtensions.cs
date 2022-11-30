using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Extensions;
using AutoTests.Framework.Core.Specflow.Utils;

namespace AutoTests.Framework.Components.Specflow.Extensions;

public static class AutoTestsAppBuilderExtensions
{
    public static AutoTestsAppBuilder UseDefaultComponentBindings(this AutoTestsAppBuilder autoTestsAppBuilder)
    {
        var specflowBindingsUtils = autoTestsAppBuilder.Container.Resolve<SpecflowBindingsUtils>();
        specflowBindingsUtils.RegisterBindings(typeof(DefaultComponentBindings));
        return autoTestsAppBuilder;
    }
}
