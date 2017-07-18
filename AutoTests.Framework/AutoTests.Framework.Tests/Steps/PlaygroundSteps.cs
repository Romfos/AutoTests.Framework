using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.Core.Steps;
using AutoTests.Framework.Models;
using AutoTests.Framework.PreProcessor.Transformations;
using AutoTests.Framework.Tests.Models;
using AutoTests.Framework.Tests.Web;
using AutoTests.Framework.Tests.Web.Pages.Login;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Tests.Steps
{
    [Binding]
    public class PlaygroundSteps : StepsBase
    {
        private readonly Application application;

        public PlaygroundSteps(Application application) : base(application.Steps)
        {
            this.application = application;
        }

        [Then(@"test model transformation:")]
        public void TestModelTransformation(ParentModel model)
        {
            Assert.AreEqual("ABC", model.Name, "Problem with model transformations");
            Assert.AreEqual(true, model.Enabled, "Problem with model transformations");
            Assert.AreEqual(123, model.SubModel.Value, "Problem with model transformations");
        }

        [Then(@"test compiler '(.*)' equal '(.*)'")]
        public void TestCompilerEqual(Calculated expected, Calculated actual)
        {
            Assert.AreEqual(expected.Get(), actual.Get(), "Problem with compiler");
        }

        [When(@"save '(.*)' as '(.*)'")]
        public void SaveAs(Calculated value, string key)
        {
            application.Stores.KeyValueStore[key] = value.Get();
        }

        [Then(@"store '(.*)' should contain '(.*)'")]
        public void StoreShouldContain(string key, Calculated value)
        {
            Assert.AreEqual(value.Get(), application.Stores.KeyValueStore[key], "Problem with store");
        }

        [Then(@"test vertical table:")]
        public void TestVerticalTable(IEnumerable<ParentModel> models)
        {
            var model = models.Single();

            Assert.AreEqual("ABC", model.Name, "Problem with vertical table transformation");
            Assert.AreEqual(true, model.Enabled, "Problem with vertical table transformation");
            Assert.AreEqual(123, model.SubModel.Value, "Problem with vertical table transformation");
        }

        [When(@"save next values:")]
        public void SaveNextValues(Dictionary<Calculated, Calculated> dictionary)
        {
            foreach (var pair in dictionary)
            {
                application.Stores.KeyValueStore[pair.Key.Get<string>()] = pair.Value.Get();
            }
        }

        [Then(@"test model attributes:")]
        public void TestModelAttributes(ParentModel model)
        {
            Assert.AreEqual("ABC", model.Name, "Problem with attribute transformation");
            Assert.AreEqual(true, model.Enabled, "Problem with attribute transformation");
            Assert.AreEqual(123, model.SubModel.Value, "Problem with attribute transformation");

            Assert.AreEqual(false, PropertyLink.Get(() => model.Name).Enabled, "Problem with attribute transformation");
            Assert.AreEqual(false, PropertyLink.Get(() => model.Enabled).Enabled,
                "Problem with attribute transformation");
            Assert.AreEqual(true, PropertyLink.Get(() => model.SubModel.Value).Enabled,
                "Problem with attribute transformation");
        }

        [Then(@"check login page setup")]
        public void CheckLoginPageSetup()
        {
            var page = application.Web.GetPage<LoginPage>();

            Assert.AreEqual("UsernameInput locator", page.UsernameInput.Locator, "Problem with login page setup");
            Assert.AreEqual("PasswordInput locator", page.PasswordInput.Locator, "Problem with login page setup");
            Assert.AreEqual("LoginButton locator", page.LoginButton.Locator, "Problem with login page setup");
        }

        [Then(@"check login page")]
        public void CheckLoginPage(LoginModel loginModel)
        {
            var page = application.Web.GetPage<LoginPage>();
            var context = application.Web.GetContext<DemoContext>();

            page.Login(loginModel);

            Assert.AreEqual(3, context.Log.Count, "Problem with login page binding");
            Assert.AreEqual("SetValue(UsernameInput locator, User1)", context.Log[0],
                "Problem with login page binding");
            Assert.AreEqual("SetValue(PasswordInput locator, Pass1)", context.Log[1],
                "Problem with login page binding");
            Assert.AreEqual("Click(LoginButton locator)", context.Log[2], "Problem with login page binding");
        }

        [Then(@"test model model transformation with name column:")]
        public void TestModelModelTransformationWithNameColumn(ParentModel model)
        {
            Assert.AreEqual(default(string), model.Name, "Problem with transformations");
            Assert.AreEqual(default(bool), model.Enabled, "Problem with transformations");
            Assert.AreEqual(default(int), model.SubModel.Value, "Problem with transformations");
        }

        [Then(@"test model model transformation with name column with attributes:")]
        public void TestModelModelTransformationWithNameColumnWithAttributes(ParentModel model)
        {
            Assert.AreEqual(default(string), model.Name, "Problem with transformations");
            Assert.AreEqual(false, PropertyLink.Get(() => model.Name).Enabled, "Problem with transformations");

            Assert.AreEqual(default(bool), model.Enabled, "Problem with transformations");
            Assert.AreEqual(default(int), model.SubModel.Value, "Problem with transformations");
        }
    }
}