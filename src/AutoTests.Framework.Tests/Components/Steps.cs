using AutoTests.Framework.Tests.Components.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Tests.Components;

[Binding]
internal sealed class Steps
{
    private readonly Application application;

    public Steps(Application application)
    {
        this.application = application;
    }

    [Then(@"check component test 1")]
    public void ThenCheckComponentTest1()
    {
        Assert.IsTrue(application!.MainPage!.Login!.Clicked);
    }

    [Then(@"check component test 2")]
    public void ThenCheckComponentTest2()
    {
        Assert.AreEqual("Hello World!", application!.MainPage!.FirstName!.value);
    }

    [Given(@"prepare component test 3")]
    public void GivenPrepareComponentTest3()
    {
        application!.MainPage!.FirstName!.value = "123";
    }

    [Then(@"check component test 3")]
    public void ThenCheckComponentTest()
    {
        Assert.IsTrue(application!.MainPage!.FirstName!.getted);
    }

    [Then(@"check component data 4")]
    public void ThenCheckComponentData()
    {
        Assert.AreEqual("abcd", application!.MainPage!.DataComponent!.Locator);
    }
}
