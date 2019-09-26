using AutoTests.Framework.Web;
using AutoTests.Framework.Web.Attributes;
using AutoTests.Framework.Web.Services;

namespace AutoTests.Framework.Tests.Web.Components.ConentAttributeTest
{
    public class ConentAttributeTestTopComponent : Component
    {
        [Content("1")]
        public ConentAttributeTestNestedComponent NestedCompnent { get; set; }

        public ConentAttributeTestTopComponent(ComponentService componentService) : base(componentService)
        {
        }
    }
}
