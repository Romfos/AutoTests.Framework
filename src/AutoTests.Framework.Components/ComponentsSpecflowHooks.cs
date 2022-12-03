using AutoTests.Framework.Components.Application;
using AutoTests.Framework.Components.Services;
using BoDi;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Components;

[Binding]
public sealed class ComponentsSpecflowHooks
{
    private readonly ComponentService componentService;

    public ComponentsSpecflowHooks(ComponentService componentService)
    {
        this.componentService = componentService;
    }

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
