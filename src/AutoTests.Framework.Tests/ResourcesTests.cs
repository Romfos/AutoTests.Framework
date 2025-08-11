using AutoTests.Framework.Resources;
using BddDotNet;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AutoTests.Framework.Tests;

[TestClass]
public sealed class ResourcesTests
{
    [TestMethod]
    public async Task DynamicDataServiceTest()
    {
        var traces = new List<object?>();

        await TestPlatform.RunTestAsync((Action<IServiceCollection>)(services =>
        {
            services.AddSingleton(traces);

            services.DynamicResourcesData([Assembly.GetExecutingAssembly()]);

            services.Scenario<RoutingTests>("feature1", "scenario1", context => context.When("step1"));
            services.When(new("step1"), Step1);

            void Step1(IDynamicDataService dynamicDataService)
            {
                traces.Add(dynamicDataService.Data.Common.TestKey);
            }
        }));

        Assert.IsTrue(traces is ["TestValue"]);
    }
}
