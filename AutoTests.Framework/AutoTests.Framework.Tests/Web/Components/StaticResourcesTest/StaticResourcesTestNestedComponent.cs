using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Services;

namespace AutoTests.Framework.Tests.Web.Components.StaticResourcesTest
{
    public class StaticResourcesTestNestedComponent : Component
    {
        public int Value { get; set; }
        public string ValueFromTopResource { get; set; }
        public StaticResourcesTestNestedComponent(ComponentService componentService) : base(componentService)
        {
        }
    }
}
