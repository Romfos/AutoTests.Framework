using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Routes.Attributes;
using AutoTests.Framework.Components.Services;

namespace AutoTests.Framework.Tests.Web.Components.RoutesTest;

[Route("RoutesTestNestedComponent")]
public class RoutesTestTopComponent : Component
{
    [Route("NestedComponent")]
    public RoutesTestNestedComponent NestedComponent { get; set; }

    public RoutesTestTopComponent(ComponentService componentService) : base(componentService)
    {
    }
}
