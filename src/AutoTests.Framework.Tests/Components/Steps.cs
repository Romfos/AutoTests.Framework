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
}
