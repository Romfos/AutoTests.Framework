using System.Collections.Generic;
using System.Linq;
using AutoTests.Demo.Common;
using AutoTests.Demo.Common.Models;
using AutoTests.Framework.PreProcessor.Transformations;
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

        [Then(@"test compiler '(.*)' equal '(.*)'")]
        public void TestCompilerEqual(Calculated expected, Calculated actual)
        {
            Assert.AreEqual(expected.Get(), actual.Get());
        }

        [When(@"save '(.*)' as '(.*)'")]
        public void SaveAs(Calculated value, string key)
        {
            application.Stores.ObjectStore[key] = value.Get();
        }

        [Then(@"store '(.*)' should contain '(.*)'")]
        public void StoreShouldContain(string key, Calculated value)
        {
            Assert.AreEqual(value.Get(), application.Stores.ObjectStore[key]);
        }

        [Then(@"test vertical table:")]
        public void TestVerticalTable(IEnumerable<ParentModel> models)
        {
            var model = models.Single();

            Assert.AreEqual("ABC", model.Name);
            Assert.AreEqual(true, model.Enabled);
            Assert.AreEqual(123, model.SubModel.Value);
        }
    }
}