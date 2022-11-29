using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Services;

namespace AutoTests.Framework.Tests.Web.Components.PrivateMemberTest;

    public class PrivateMemberTestTopComponent : Component
    {
        private PrivateMemberTestNestedComponent FirstNestedComponent { set; get; }
        
        [Content("123")]
        private PrivateMemberTestNestedComponent SecondNestedComponent { get; set; }

        public PrivateMemberTestTopComponent(ComponentService componentService) : base(componentService)
        {
        }

        public PrivateMemberTestNestedComponent GetFirstNestedComponent()
        {
            return FirstNestedComponent;
        }

        public PrivateMemberTestNestedComponent GetSecondNestedComponent()
        {
            return SecondNestedComponent;
        }
    }
