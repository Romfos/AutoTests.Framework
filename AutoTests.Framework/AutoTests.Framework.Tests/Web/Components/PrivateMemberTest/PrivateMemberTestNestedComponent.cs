using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Services;

namespace AutoTests.Framework.Tests.Web.Components.PrivateMemberTest;

    public class PrivateMemberTestNestedComponent : Component
    {
        [Primary]
        private string Value { get; set; }

        public PrivateMemberTestNestedComponent(ComponentService componentService) : base(componentService)
        {
        }

        public string GetPrivatePropertyValue()
        {
            return Value;
        }
    }
