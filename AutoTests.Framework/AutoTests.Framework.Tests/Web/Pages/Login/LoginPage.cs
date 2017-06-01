using AutoTests.Framework.Tests.Web.Controls;
using AutoTests.Framework.Web.Binding;

namespace AutoTests.Framework.Tests.Web.Pages.Login
{
    public class LoginPage : DemoPage
    {
        public Input UsernameInput { get; private set; }
        public Input PasswordInput { get; private set; }
        public Button LoginButton { get; private set; }

        public LoginPage(Application application) : base(application)
        {
        }

        private Binder<LoginModel> GetLoginModelBinder(LoginModel loginModel)
        {
            return new Binder<LoginModel>(loginModel)
                .Bind(() => loginModel.Username, UsernameInput)
                .Bind(() => loginModel.Password, PasswordInput);
        }

        public void Login(LoginModel loginModel)
        {
            GetLoginModelBinder(loginModel).SetValue();
            LoginButton.Click();
        }
    }
}