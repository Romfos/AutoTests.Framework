using System.Linq;
using System.Text.RegularExpressions;
using AutoTests.Tools.Refactroings.Entities;
using AutoTests.Tools.Refactroings.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTests.Tools.Refactroings.Tests.Tests
{
    [TestClass]
    public class CommonRefactroingsTests : RefactroingsTestsBase
    {
        [TestMethod]
        public void FindStepLocationsTest()
        {
            var steps = StepsRefactroings.Find(x => x.Text == "test").ToArray();

            Assert.AreEqual(2, steps.Length);
        }

        [TestMethod]
        public void ChangePropertyNameTest()
        {
            ModelRefactroings.ChangePropertyName<RenameModel>("Number", "Id");

            var step1 = StepsRefactroings.Find(x => x.Text == "rename model one").Single().step;
            var step2 = StepsRefactroings.Find(x => x.Text == "rename model two").Single().step;

            Assert.AreEqual("Id", step1.Table.Rows[0].Items[0].Name);
            Assert.AreEqual("Id", step2.Table.Rows[0].Items[0].Name);
            Assert.AreEqual("Id", step2.Table.Rows[1].Items[0].Name);
        }

        [TestMethod]
        public void RenameTest()
        {
            var oldStepAttribute = new StepAttribute
            {
                StepType = StepType.Then,
                Regex = new Regex("the result should be (.*) on the screen")
            };

            var newStepAttribute = new StepAttribute
            {
                StepType = StepType.Then,
                Regex = new Regex("test (.*) test")
            };
            
            StepsRefactroings.Rename("test {0} test", oldStepAttribute, newStepAttribute);
            
            Assert.AreEqual(false, StepsRefactroings.Find(x => oldStepAttribute.Regex.IsMatch(x.Text)).Any());
            Assert.AreEqual(true, StepsRefactroings.Find(x => newStepAttribute.Regex.IsMatch(x.Text)).Any());
        }
    }
}