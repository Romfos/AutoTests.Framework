using BootstrapTests.Web.Common;
using TechTalk.SpecFlow;

namespace BootstrapTests.Steps
{
    [Binding]
    public class CommonSteps : StepsBase
    {
        public CommonSteps(Application application) : base(application)
        {
        }

        [Given(@"navigate to '(.*)'")]
        public void GivenNavigateTo(string url)
        {
            Application.GetContext<CommonContext>().Navigate(url);
        }
    }
}
