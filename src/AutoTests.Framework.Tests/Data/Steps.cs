using AutoTests.Framework.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Tests.Data;

[Binding]
public sealed class Steps(DataService service)
{
    [Then(@"test data step 1")]
    public void ThenTestDataStep()
    {
        Assert.AreEqual("Value", service.Data.TestData.String);
    }
}
