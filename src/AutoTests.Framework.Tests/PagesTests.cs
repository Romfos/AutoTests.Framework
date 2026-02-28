using AutoTests.Framework.Options;
using AutoTests.Framework.Pages;
using AutoTests.Framework.Routing;
using BddDotNet.Scenarios;
using BddDotNet.Steps;
using Microsoft.Extensions.DependencyInjection;

namespace AutoTests.Framework.Tests;

[TestClass]
public sealed class PagesTests
{
    [TestMethod]
    public async Task RoutingServiceTest()
    {
        var traces = new List<object?>();

        await TestPlatform.RunTestAsync(services =>
        {
            services.AddSingleton(traces);

            services.Page<PagesClass>("page1");

            services.Scenario("feature1", "scenario1", async context =>
            {
                await context.When("step1");
                await context.When("step2");
            });

            services.When(new("step1"), (IRoutingService routingService) => traces.Add(
                routingService.GetComponent<TestComponent1>("page1 > component1")));

            services.When(new("step2"), (IRoutingService routingService) => traces.Add(
                routingService.GetComponent<TestComponent2>("page1 > component2")));
        });

        Assert.IsTrue(traces is [TestComponent1 { Options: "abc" }, TestComponent2 { Options: 123 }]);
    }
}

file sealed class PagesClass
{
    [Route("component1")]
    [Options("abc")]
    public required TestComponent1 TestComponent1 { get; init; }

    [Route("component2")]
    [Options(123)]
    public required TestComponent2 TestComponent2 { get; init; }
}

file sealed class TestComponent1([FromKeyedServices] IComponentOptions options) : IComponent
{
    public string Options => options.Get<string>();
}

file sealed class TestComponent2([FromKeyedServices] IComponentOptions options) : IComponent
{
    public int Options => options.Get<int>();
}
