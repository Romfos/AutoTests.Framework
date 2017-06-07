using AutoTests.Framework.Web.Binding;
using AutoTests.Web.Controls;

namespace AutoTests.Web.Pages.Login
{
    public class LoginPage : SemanticPage
    {
        private Input UsernameInput { get; set; }
        private Input PasswordInput { get; set; }
        private Button LoginButton { get; set; }

        public LoginPage(Application application) : base(application)
        {
        }

        private Binder<LoginModel> BindLoginModel()
        {
            return new Binder<LoginModel>()
                .Bind(x => x.Username, UsernameInput)
                .Bind(x => x.Password, PasswordInput);
        }

        public void Login(LoginModel model)
        {
            BindLoginModel().SetValue(model);
            LoginButton.Click();
        }
    }
}