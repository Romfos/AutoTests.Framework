using System.Threading.Tasks;
using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Routes.Attributes;
using AutoTests.Framework.Components.Services;
using AutoTests.Framework.Components.Specflow.Contracts;

namespace AutoTests.Framework.Tests.Web.Components.ContractTests;

[Route("enabled test component")]
public class EnabledTestComponent : Component, IEnabled, IInternalComponentStatus
{
    public bool InternalComponentStatus { get; set; }

    public EnabledTestComponent(ComponentService componentService) : base(componentService)
    {
    }

    public Task<bool> IsEnabledAsync()
    {
        InternalComponentStatus = true;
        return Task.FromResult(true);
    }
}
