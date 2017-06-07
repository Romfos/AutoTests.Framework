using System.Collections.Generic;
using AutoTests.Tools.Refactroings.Tests.Models;
using TechTalk.SpecFlow;

namespace AutoTests.Tools.Refactroings.Tests.Steps
{
    [Binding]
    public class PlaygroundSteps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"test")]
        public void GivenTest(StubModel table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"rename model one")]
        public void GivenRenameModelOne(RenameModel model)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"rename model two")]
        public void GivenRenameModelTwo(IEnumerable<RenameModel> model)
        {
            ScenarioContext.Current.Pending();
        }
    }
}