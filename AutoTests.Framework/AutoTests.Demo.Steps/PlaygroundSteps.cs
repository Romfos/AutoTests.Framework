using AutoTests.Demo.Common;
using AutoTests.Demo.Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AutoTests.Demo.Steps
{
    [Binding]
    public class PlaygroundSteps
    {
        private readonly Application application;

        public PlaygroundSteps(Application application)
        {
            this.application = application;
        }
        
        [Then(@"test model transformation:")]
        public void TestModelTransformation(ParentModel model)
        {
            Assert.AreEqual("ABC", model.Name);
            Assert.AreEqual(true, model.Enabled);
            Assert.AreEqual(123, model.SubModel.Value);
        }
    }
}