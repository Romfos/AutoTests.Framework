using AutoTests.Framework.Web;
using AutoTests.Framework.Web.Services;

namespace AutoTests.Framework.Tests.Web.Components
{
    public class NestedComponentsTestComponent : Component
    {
        public JsonResourceTestSubComponent NestedCompnent { get; set; }

        public NestedComponentsTestComponent(ComponentService componentService) : base(componentService)
        {
        }
    }
}
