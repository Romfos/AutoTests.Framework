using AutoTests.Framework.Tests.Web.Elements;
using AutoTests.Framework.Web.Binding;

namespace AutoTests.Framework.Tests.Web.Pages.Login
{
    public class LoginPage : DemoPage
    {
        public Input Username { get; set; }
        public Input Password { get; set; }
        public Button Login { get; set; }

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