using AutoTests.Framework.Components.Application;
using AutoTests.Framework.Components.Services;
using Reqnroll;
using Reqnroll.BoDi;

namespace AutoTests.Framework.Components;

[Binding]
public sealed class ComponentsReqnrollHooks(ComponentService componentService)
{
    [StepArgumentTransformation]
    public ComponentReference TransformComponentReference(string path)
    {
        return new ComponentReference(componentService, path);
    }

    [BeforeScenario(Order = 1100)]
    public static void RegisterApplication(ITestRunnerManager testRunnerManager, IObjectContainer objectContainer)
    {
        var application = objectContainer
            .Resolve<ApplicationFactory>()
            .Create(testRunnerManager.BindingAssemblies, objectContainer);

        objectContainer.RegisterInstanceAs(application);
        objectContainer.RegisterInstanceAs(application, application.GetType());
    }
}
