using AutoTests.Framework.Web;
using AutoTests.Framework.Web.Attributes;
using AutoTests.Framework.Web.Services;

namespace AutoTests.Framework.Tests.Web.Components.ConentAttributeTest
{
    public class ConentAttributeTestNestedComponent : Component
    {
        [Primary]
        public string Value { get; set; }

        public ConentAttributeTestNestedComponent(ComponentService componentService) : base(componentService)
        {
        }
    }
}
