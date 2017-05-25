using System.Collections.Generic;
using AutoTests.Framework.Core.Steps;
using AutoTests.Framework.PreProcessor.Transformations;
using AutoTests.Web;
using AutoTests.Web.Pages.Login;
using TechTalk.SpecFlow;

namespace AutoTests.Steps
{
    [Binding]
    public class PlaygroundSteps : StepsBase
    {
        private readonly Application application;

        public PlaygroundSteps(Application application) 
            : base(application.Steps)
        {
            this.application = application;
        }

        [Given(@"save '(.*)' as '(.*)'")]
        public void SaveAs(Calculated value, string key)
        {
            application.Stores.ObjectStore[key] = value.Get();
        }

        [When(@"navigate to '(.*)'")]
        public void NavigateTo(string url)
        {
            application.Web.GetContext<SemanticContext>().Navigate(url);
        }

        [When(@"login as")]
        public void LoginAs(LoginModel model)
        {
            application.Web.GetPage<LoginPage>().Login(model);
        }

        [Then(@"in store '(.*)' should contain '(.*)'")]
        public void InStoreShouldContain(string key, Calculated value)
        {
            var expected = value.Get();
            var actual = application.Stores.ObjectStore[key];
            Assert.AreEqual(expected, actual, "Incorrect value");
        }

        [Given(@"save next values in store:")]
        public void SaveNextValuesInStore(Dictionary<Calculated, Calculated> dictionary)
        {
            foreach (var pair in dictionary)
            {
                application.Stores.ObjectStore[pair.Key.Get<string>()] = pair.Value.Get();
            }
        }
    }
}