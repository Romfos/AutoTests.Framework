using BoDi;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Data;

[Binding]
public sealed class DataSpecflowHooks(ITestRunnerManager testRunnerManager, IObjectContainer objectContainer)
{
    [BeforeScenario]
    public void BeforeTestRun()
    {
        var dataLoader = objectContainer.Resolve<DataLoader>();
        var data = dataLoader.Load(testRunnerManager.BindingAssemblies);
        var dataService = new DataService(data);
        objectContainer.RegisterInstanceAs(dataService);
    }
}
