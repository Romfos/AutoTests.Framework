using AutoTests.Demo.Common.Web.Controls;

namespace AutoTests.Demo.Common.Web.Pages.Login
{
    public class LoginPage : DemoPage
    {
        public Input UsernameInput { get; private set; }
        public Input PasswordInput { get; private set; }
        public Button LoginButton { get; private set; }

        public LoginPage(Application application) : base(application)
        {
        }
    }
}