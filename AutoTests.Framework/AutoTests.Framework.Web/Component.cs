using AutoTests.Framework.Web.Services;

namespace AutoTests.Framework.Web
{
    public abstract class Component
    {
        protected Component(ComponentService componentService)
        {
            componentService.InitializeComponent(this);
        }
    }
}
