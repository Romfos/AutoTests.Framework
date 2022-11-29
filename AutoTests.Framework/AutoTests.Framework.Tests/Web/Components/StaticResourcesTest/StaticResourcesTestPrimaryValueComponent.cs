using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Services;

namespace AutoTests.Framework.Tests.Web.Components.StaticResourcesTest;

    public class StaticResourcesTestPrimaryValueComponent : Component
    {
        [Primary]
        public string PrimaryValue { get; set; }

        public StaticResourcesTestPrimaryValueComponent(ComponentService componentService) : base(componentService)
        {
        }
    }
