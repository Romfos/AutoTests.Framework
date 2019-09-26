using AutoTests.Framework.Web;
using AutoTests.Framework.Web.Routes.Attributes;
using AutoTests.Framework.Web.Services;

namespace AutoTests.Framework.Tests.Web.Components.RoutesTest
{
    [Route("RoutesTestNestedComponent")]
    public class RoutesTestTopComponent : Component
    {
        [Route("NestedComponent")]
        public RoutesTestNestedComponent NestedComponent { get; set; }

        public RoutesTestTopComponent(ComponentService componentService) : base(componentService)
        {
        }
    }
}
