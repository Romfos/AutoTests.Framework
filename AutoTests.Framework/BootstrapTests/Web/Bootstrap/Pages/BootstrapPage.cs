using AutoTests.Framework.PageObjects;

namespace BootstrapTests.Web.Bootstrap.Pages
{
    public abstract class BootstrapPage : Page
    {
        protected Application Application { get; }

        protected BootstrapPage(Application application) : base(application.PageObjects)
        {
            Application = application;
        }
    }
}
