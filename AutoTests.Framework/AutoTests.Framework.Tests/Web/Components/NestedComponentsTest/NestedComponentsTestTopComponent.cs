using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Services;

namespace AutoTests.Framework.Tests.Web.Components.NestedComponentsTest;

    public class NestedComponentsTestTopComponent : Component
    {
        public NestedComponentsTestNestedComponent NestedCompnent { get; set; }

        public NestedComponentsTestTopComponent(ComponentService componentService) : base(componentService)
        {
        }
    }
