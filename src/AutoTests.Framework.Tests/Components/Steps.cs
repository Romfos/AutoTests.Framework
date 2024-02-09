using AutoTests.Framework.Tests.Components.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;

namespace AutoTests.Framework.Tests.Components;

[Binding]
internal sealed class Steps(Application application)
{
    [Then(@"check component test 1")]
    public void ThenCheckComponentTest1()
    {
        Assert.IsTrue(application.MainPage?.Login?.Clicked);
    }

    [Then(@"check component test 2")]
    public void ThenCheckComponentTest2()
    {
        Assert.AreEqual("Hello World!", application.MainPage?.FirstName?.setValueContent);
    }

    [Given(@"prepare component test 3")]
    public void GivenPrepareComponentTest3()
    {
        application.MainPage!.FirstName!.setValueContent = "123";
    }

    [Then(@"check component test 3")]
    public void ThenCheckComponentTest()
    {
        Assert.IsTrue(application.MainPage?.FirstName?.isGetMethodCalled);
    }

    [Then(@"check component data 4")]
    public void ThenCheckComponentData()
    {
        Assert.AreEqual("abcd", application.MainPage?.DataComponent?.Locator);
    }

    [Then(@"check component data 5")]
    public void ThenCheckComponentData5()
    {
        Assert.AreEqual("12345", application.MainPage?.Locator?.Selector);
    }
}
