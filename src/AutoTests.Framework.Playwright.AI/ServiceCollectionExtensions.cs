using AutoTests.Framework.Playwright.AI.Options;
using AutoTests.Framework.Playwright.AI.Options.Internal;
using AutoTests.Framework.Playwright.AI.Resources;
using AutoTests.Framework.Playwright.AI.Resources.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Playwright;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace AutoTests.Framework.Playwright.AI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection SinglePageChromiumPlaywrightWithAILearning(
        this IServiceCollection services,
        BrowserTypeLaunchOptions browserTypeLaunchOptions,
        string locatorsCacheFile)
    {
        services.AddScoped(_ => OptionsCache.Create(new FileInfo(locatorsCacheFile)));

        services.AddScoped<IOptionsService, OptionsService>();

        services.TryAddSingleton(_ =>
        {
            Program.Main(["install", "chromium"]);
            return Microsoft.Playwright.Playwright.CreateAsync().Result;
        });

        services.TryAddSingleton(browserTypeLaunchOptions);

        services.TryAddSingleton(services =>
        {
            var playwright = services.GetRequiredService<IPlaywright>();
            var browserTypeLaunchOptions = services.GetRequiredService<BrowserTypeLaunchOptions>();
            return playwright.Chromium.LaunchAsync(browserTypeLaunchOptions).Result;
        });

        services.TryAddSingleton(services =>
        {
            var browser = services.GetRequiredService<IBrowser>();
            return browser.NewPageAsync().Result;
        });

        services.SourceGeneratedGherkinSteps();

        return services;
    }

    [RequiresUnreferencedCode("This method is reflection based and not Trimmng and AOT firendly")]
    [RequiresDynamicCode("This method is reflection based and not Trimmng and AOT firendly")]
    public static IServiceCollection DynamicResourcesData(this IServiceCollection services, Assembly[] assemblies)
    {
        services.TryAddSingleton<IDynamicDataService>(_ => new DynamicDataService(new JsonDataLoader().Load(assemblies)));

        return services;
    }
}
