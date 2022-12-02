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
    public void ThenCheckComponentTest()
    {
        Assert.IsTrue(application!.MainPage!.Button!.Clicked);
    }
}
