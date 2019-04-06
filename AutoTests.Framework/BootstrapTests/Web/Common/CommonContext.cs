namespace BootstrapTests.Web.Common
{
    public class CommonContext : Context
    {
        public CommonContext(Application application) : base(application)
        {
        }

        public void Navigate(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }
    }
}
