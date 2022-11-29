using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Services;

namespace AutoTests.Framework.Tests.Web.Components.ConentAttributeTest;

public class ConentAttributeTestTopComponent : Component
{
    [Content("1")]
    public ConentAttributeTestNestedComponent NestedCompnent { get; set; }

    public ConentAttributeTestTopComponent(ComponentService componentService) : base(componentService)
    {
    }
}
