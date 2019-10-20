using AutoTests.Framework.Models;
using AutoTests.Framework.Tests.Models.Transformations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Tests.Specflow.Steps
{
    [Binding]
    public class ModelsSteps
    {
        [Then(@"check single model transformation:")]
        public void ThenCheckSingleModelTransformation(SingleModelTransformationTestModel model)
        {
            Assert.AreEqual(1, model.Data);
            Assert.AreEqual(3, model.Value2);

            Assert.IsFalse(PropertyLink.From(() => model.Value3).Enabled);
        }

        [Then(@"check list of model transformation:")]
        public void ThenCheckListOfModelTransformation(List<ListOfModelTransformationTestModel> models)
        {
            Assert.AreEqual(1, models[0].Value1);
            Assert.AreEqual(3, models[0].Value2);
            Assert.AreEqual(3, models[1].Value1);
            Assert.AreEqual(4, models[1].Value2);
        }
    }
}
