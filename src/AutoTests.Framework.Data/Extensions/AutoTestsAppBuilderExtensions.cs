using AutoTests.Framework.Core;
using System.Reflection;
using System.Text.RegularExpressions;
using AutoTests.Framework.Core.Extensions;
using AutoTests.Framework.Data.Loaders;

namespace AutoTests.Framework.Data.Extensions;

public static class AutoTestsAppBuilderExtensions
{
    public static AutoTestsAppBuilder UseJsonResource(this AutoTestsAppBuilder autoTestsAppBuilder,
        Assembly assembly, string resourceName, DataPath? basePath = null)
    {
        var jsonDataHubLoader = autoTestsAppBuilder.Container.Resolve<JsonResourceLoader>();
        var dataHub = autoTestsAppBuilder.Container.Resolve<DataHub>();
        jsonDataHubLoader.LoadJsonResource(dataHub, assembly, resourceName, basePath);
        return autoTestsAppBuilder;
    }

    public static AutoTestsAppBuilder UseJsonResources(this AutoTestsAppBuilder autoTestsAppBuilder,
        Assembly assembly, Regex regex, bool includeResourceName = true, DataPath? basePath = null)
    {
        var jsonDataHubLoader = autoTestsAppBuilder.Container.Resolve<JsonResourceLoader>();
        var dataHub = autoTestsAppBuilder.Container.Resolve<DataHub>();
        jsonDataHubLoader.LoadJsonResources(dataHub, assembly, regex, includeResourceName, basePath);
        return autoTestsAppBuilder;
    }

    public static AutoTestsAppBuilder UseTextResource(this AutoTestsAppBuilder autoTestsAppBuilder,
        Assembly assembly, string resourceName, DataPath path)
    {
        var textDataHubLoader = autoTestsAppBuilder.Container.Resolve<TextResourceLoader>();
        var dataHub = autoTestsAppBuilder.Container.Resolve<DataHub>();
        textDataHubLoader.LoadTextResource(dataHub, assembly, resourceName, path);
        return autoTestsAppBuilder;
    }

    public static AutoTestsAppBuilder UseTextResources(this AutoTestsAppBuilder autoTestsAppBuilder,
        Assembly assembly, Regex regex, DataPath? basePath = null)
    {
        var textDataHubLoader = autoTestsAppBuilder.Container.Resolve<TextResourceLoader>();
        var dataHub = autoTestsAppBuilder.Container.Resolve<DataHub>();
        textDataHubLoader.LoadTextResources(dataHub, assembly, regex, basePath);
        return autoTestsAppBuilder;
    }
}
