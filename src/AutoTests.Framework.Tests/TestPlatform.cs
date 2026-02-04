using BddDotNet;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Testing.Platform.Builder;

namespace AutoTests.Framework.Tests;

internal static class TestPlatform
{
    public static async Task<int> RunTestAsync(Action<IServiceCollection> configure)
    {
        var builder = await TestApplication.CreateBuilderAsync([]);
        var services = builder.AddBddDotNet();
        services.AutoTestsFramework();
        configure(services);
        using var testApp = await builder.BuildAsync();
        return await testApp.RunAsync();
    }
}
