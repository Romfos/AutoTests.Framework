using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Routes.Attributes;
using AutoTests.Framework.Components.Services;
using AutoTests.Framework.Components.Specflow.Contracts;
using System.Threading.Tasks;

namespace AutoTests.Framework.Tests.Web.Components.ContractTests;

[Route("selected test component")]
public class SelectedTestComponent : Component, ISelected, IInternalComponentStatus
{
    public bool InternalComponentStatus { get; set; }

    public SelectedTestComponent(ComponentService componentService) : base(componentService)
    {
    }

    public Task<bool> IsSelectedAsync()
    {
        InternalComponentStatus = true;
        return Task.FromResult(true);
    }
}
