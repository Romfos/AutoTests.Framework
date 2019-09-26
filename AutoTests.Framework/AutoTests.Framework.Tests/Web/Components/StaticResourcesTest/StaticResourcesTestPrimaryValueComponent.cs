using AutoTests.Framework.Web;
using AutoTests.Framework.Web.Attributes;
using AutoTests.Framework.Web.Services;

namespace AutoTests.Framework.Tests.Web.Components.StaticResourcesTest
{
    public class StaticResourcesTestPrimaryValueComponent : Component
    {
        [Primary]
        public string PrimaryValue { get; set; }

        public StaticResourcesTestPrimaryValueComponent(ComponentService componentService) : base(componentService)
        {
        }
    }
}
