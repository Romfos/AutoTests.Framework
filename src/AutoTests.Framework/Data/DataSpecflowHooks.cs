using BoDi;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Data;

[Binding]
public sealed class DataSpecflowHooks
{
    [BeforeTestRun]
    public static void BeforeTestRun(ITestRunnerManager testRunnerManager, IObjectContainer objectContainer)
    {
        var dataLoader = objectContainer.Resolve<DataLoader>();
        var data = dataLoader.Load(testRunnerManager.BindingAssemblies);
        var dataService = new DataService(data);
        objectContainer.RegisterInstanceAs<IDataService>(dataService);
    }
}
