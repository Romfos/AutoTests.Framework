using AutoTests.Framework.Web.Common;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Example.Steps
{
    [Binding]
    public class CommonSteps : Steps
    {
        public CommonSteps(Application application) : base(application)
        {
        }

        [Given(@"navigate to '(.*)'")]
        public void NavigateTo(string url)
        {
            application.Web.GetContext<CommonContext>().Navigate(url);
        }
    }
}