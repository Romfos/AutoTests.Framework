using AutoTests.Framework.Components.Services;

namespace AutoTests.Framework.Components
{
    public abstract class Component
    {
        protected Component(ComponentService componentService)
        {
            componentService.InitializeComponent(this);
        }
    }
}
