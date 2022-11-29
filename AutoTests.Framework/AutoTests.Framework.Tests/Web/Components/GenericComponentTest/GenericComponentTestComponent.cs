using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Services;

namespace AutoTests.Framework.Tests.Web.Components.GenericComponentTest;

    public class GenericComponentTestComponent<T> : Component
    {
        public int Value { get; set; }

        public GenericComponentTestComponent(ComponentService componentService) : base(componentService)
        {
        }
    }
