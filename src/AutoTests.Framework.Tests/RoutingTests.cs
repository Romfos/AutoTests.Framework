using AutoTests.Framework.Routing;
using BddDotNet.Scenarios;
using BddDotNet.Steps;
using Microsoft.Extensions.DependencyInjection;

namespace AutoTests.Framework.Tests;

[TestClass]
public sealed class RoutingTests
{
    [TestMethod]
    public async Task RoutingServiceTest()
    {
        var traces = new List<object?>();

        await TestPlatform.RunTestAsync(services =>
        {
            services.AddSingleton(traces);

            services.Component<TestComponent1>("page1 > component1");
            services.Component<TestComponent2>("page1 > component2");

            services.Scenario("feature1", "scenario1", context => context.When("step1"));

            services.When(new("step1"), (IRoutingService routingService) =>
            {
                traces.Add(routingService.GetComponent<TestComponent1>("page1 > component1"));
                traces.Add(routingService.GetComponent<TestComponent2>("page1 > component2"));
            });
        });

        Assert.IsTrue(traces is [TestComponent1, TestComponent2]);
    }
}

file sealed class TestComponent1 : IComponent;

file sealed class TestComponent2 : IComponent;
