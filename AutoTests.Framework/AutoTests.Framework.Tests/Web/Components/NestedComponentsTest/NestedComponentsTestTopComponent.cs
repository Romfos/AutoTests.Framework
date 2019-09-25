using AutoTests.Framework.Web;
using AutoTests.Framework.Web.Services;

namespace AutoTests.Framework.Tests.Web.Components.NestedComponentsTest
{
    public class NestedComponentsTestTopComponent : Component
    {
        public NestedComponentsTestNestedComponent NestedCompnent { get; set; }

        public NestedComponentsTestTopComponent(ComponentService componentService) : base(componentService)
        {
        }
    }
}
