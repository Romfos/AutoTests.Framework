using AutoTests.Framework.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTests.Framework.Tests.UnitTests
{
    [TestClass]
    public class DataTests : UnitTestsBase
    {
        [TestMethod]
        public void DataHubTest()
        {
            var dataHub = new DataHub();

            dataHub.Add(new DataPath("a.b.c".Split('.')), 123);
            dataHub.Add(new DataPath("a.b.d".Split('.')), 456);
            dataHub.Add(new DataPath("e.b.d".Split('.')), 789);
            var data = dataHub.CreateDynamicObject();

            Assert.AreEqual(123, data.a.b.c);
            Assert.AreEqual(456, data.a.b.d);
            Assert.AreEqual(789, data.e.b.d);
        }
    }
}
