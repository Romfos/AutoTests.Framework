using Reqnroll;
using Reqnroll.BoDi;

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
        objectContainer.RegisterInstanceAs(dataService);
    }
}
