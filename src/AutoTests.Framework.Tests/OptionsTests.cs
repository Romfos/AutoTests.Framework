using AutoTests.Framework.Options;
using BddDotNet;
using Microsoft.Extensions.DependencyInjection;

namespace AutoTests.Framework.Tests;

[TestClass]
public sealed class OptionsTests
{
    [TestMethod]
    public async Task OptionsServiceTest()
    {
        var traces = new List<object?>();

        await TestPlatform.RunTestAsync(services =>
        {
            services.AddSingleton(traces);

            services.ComponentOptions("page1 > component1", "abc");
            services.ComponentOptions("page1 > component2", 123);

            services.Scenario<RoutingTests>("feature1", "scenario1", context => context.When("step1"));

            services.When(new("step1"), (IOptionsService optionsService) =>
            {
                traces.Add(optionsService.GetOptions<string>("page1 > component1"));
                traces.Add(optionsService.GetOptions<int>("page1 > component2"));
            });
        });

        Assert.IsTrue(traces is ["abc", 123]);
    }
}
