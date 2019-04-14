using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTests.Framework.Tests.UnitTests
{
    [TestClass]
    public class ConfigurationTests : UnitTestsBase
    {
        [TestMethod]
        public void ConfigurationProviderTest()
        {
            var configurationProvider = application.Configuration.ConfigurationProvider;
            configurationProvider.Add("Test.ABCD.Qwerty", 123);
            var configuration = configurationProvider.CreateExpandoObject();

            Assert.AreEqual(123, configuration.Test.ABCD.Qwerty);
        }
    }
}
