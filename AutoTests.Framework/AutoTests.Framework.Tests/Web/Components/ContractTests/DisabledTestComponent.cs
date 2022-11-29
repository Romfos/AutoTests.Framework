using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Routes.Attributes;
using AutoTests.Framework.Components.Services;
using AutoTests.Framework.Components.Specflow.Contracts;
using System.Threading.Tasks;

namespace AutoTests.Framework.Tests.Web.Components.ContractTests;

[Route("disabled test component")]
public class DisabledTestComponent : Component, IEnabled, IInternalComponentStatus
{
    public bool InternalComponentStatus { get; set; }

    public DisabledTestComponent(ComponentService componentService) : base(componentService)
    {
    }

    public Task<bool> IsEnabledAsync()
    {
        InternalComponentStatus = true;
        return Task.FromResult(false);
    }
}
