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
        
        private Binder<LoginModel> BindLoginModel()
        {
            return new Binder<LoginModel>()
                .Bind(x => x.Username, UsernameInput)
                .Bind(x => x.Password, PasswordInput);
        }
        
        public void Login(LoginModel loginModel)
        {
            BindLoginModel().SetValue(loginModel);
            LoginButton.Click();
        }

        public LoginModel GetLoginModel(LoginModel expected)
        {
            return BindLoginModel().GetValue(expected);
        }
    }
}