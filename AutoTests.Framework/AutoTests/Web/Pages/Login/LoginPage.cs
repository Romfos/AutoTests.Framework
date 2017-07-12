using AutoTests.Framework.Web.Attributes;
using AutoTests.Framework.Web.Binding;
using AutoTests.Framework.Web.Common.Elements;

namespace AutoTests.Web.Pages.Login
{
    public class LoginPage : SemanticPage
    {
        [Locator("/html/body/div/div/form/div[1]/div[1]/div/input")]
        public Input Username { get; private set; }

        [Locator("/html/body/div/div/form/div[1]/div[2]/div/input")]
        public Input Password { get; private set; }

        [Locator("/html/body/div/div/form/div[1]/div[3]")]
        public Button Login { get; private set; }

        public LoginPage(Application application) : base(application)
        {
        }

        public Binder<LoginModel> BindLoginModel()
        {
            return new Binder<LoginModel>()
                .Bind(x => x.Username, Username)
                .Bind(x => x.Password, Password);
        }
    }
}