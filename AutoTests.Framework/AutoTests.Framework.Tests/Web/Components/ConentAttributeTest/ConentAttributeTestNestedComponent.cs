using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Services;

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
