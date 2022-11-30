using AutoTests.Framework.Core;
using Microsoft.CodeAnalysis.Scripting;
using AutoTests.Framework.Core.Extensions;

namespace AutoTests.Framework.PreProcessor.Roslyn.Extensions;

public static class AutoTestsAppBuilderExtensions
{
    public static AutoTestsAppBuilder UseRoslynPreProcessor(this AutoTestsAppBuilder autoTestsAppBuilder)
    {
        autoTestsAppBuilder.Container.Register<IPreProcessor>(new RoslynPreProcessor());
        return autoTestsAppBuilder;
    }

    public static AutoTestsAppBuilder UseRoslynPreProcessor<TGlobals>(
        this AutoTestsAppBuilder autoTestsAppBuilder, ScriptOptions scriptOptions)
    {
        var globals = autoTestsAppBuilder.Container.Resolve<TGlobals>();
        autoTestsAppBuilder.Container.Register<IPreProcessor>(new RoslynPreProcessor(globals, scriptOptions));
        return autoTestsAppBuilder;
    }
}
