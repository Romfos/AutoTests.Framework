using AutoTests.Framework.Web;
using AutoTests.Framework.Web.Services;

namespace AutoTests.Framework.Tests.Web.Components.StaticResourcesTest
{
    public class StaticResourcesTestTopComponent : Component
    {
        public string Value { get; set; }
        public StaticResourcesTestNestedComponent NestedComponent { get; set; }
        public StaticResourcesTestPrimaryValueComponent PrimaryValueComponent { get; set; }

        public StaticResourcesTestTopComponent(ComponentService componentService) : base(componentService)
        {
        }
    }
}
