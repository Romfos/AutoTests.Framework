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

        private Binder<LoginModel> Bind(LoginModel model)
        {
            return new Binder<LoginModel>(model)
                .Bind(() => model.Username, UsernameInput)
                .Bind(() => model.Password, PasswordInput);
        }

        public void Login(LoginModel model)
        {
            Bind(model).SetValue();
            LoginButton.Click();
        }
    }
}