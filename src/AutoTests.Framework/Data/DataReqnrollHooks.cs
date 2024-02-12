using BoDi;
using Reqnroll;

namespace AutoTests.Framework.Data;

[Binding]
public sealed class DataReqnrollHooks
{
    [BeforeTestRun]
    public static void BeforeTestRun(ITestRunnerManager testRunnerManager, ObjectContainer objectContainer)
    {
        var dataLoader = objectContainer.Resolve<DataLoader>();
        var data = dataLoader.Load(testRunnerManager.BindingAssemblies);
        var dataService = new DataService(data);
        objectContainer.BaseContainer.RegisterInstanceAs(dataService);
    }
}
