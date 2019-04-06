using AutoTests.Framework.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Tests.Steps
{
    [Binding]
    public class ModelSteps : StepsBase
    {
        public ModelSteps(Application application) : base(application)
        {
        }

        [Then(@"step with model transformation")]
        public void ThenStepWithModelTransformation(Model1 model)
        { 
            Assert.AreEqual("ABCD", model.Name);
            Assert.AreEqual(3, model.Value);
        }

        public class Model1 : Model
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
    }
}
