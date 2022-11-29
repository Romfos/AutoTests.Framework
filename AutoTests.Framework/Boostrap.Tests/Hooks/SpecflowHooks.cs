using AutoTests.Framework.Components.Specflow.Extensions;
using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Specflow;
using AutoTests.Framework.Data.Extensions;
using AutoTests.Framework.PreProcessor.Roslyn.Extensions;
using AutoTests.Framework.PreProcessor.Specflow.Extensions;
using BoDi;
using Boostrap.Tests.Web;
using Microsoft.CodeAnalysis.Scripting;
using System.Reflection;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Boostrap.Tests.Hooks;

[Binding]
public class SpecflowHooks
{
    private readonly IObjectContainer objectContainer;

    public SpecflowHooks(IObjectContainer objectContainer)
    {
        this.objectContainer = objectContainer;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        var container = new SpecflowContainer(objectContainer, Assembly.GetExecutingAssembly());

        new AutoTestsAppBuilder(container)
            .UseRoslynPreProcessor<BoostrapGlobals>(ScriptOptions.Default.AddReferences("Microsoft.CSharp"))
            .UseDefaultPreProcessorBindings()
            .UseDefaultComponentBindings()
            .UseJsonResource(Assembly.GetExecutingAssembly(), "Boostrap.Tests.Data.Common.json");

        container.Register(PlaywrightFactory.GetPage());
    }

    [BeforeTestRun]
    public static async Task BeforeTestRun()
    {
        await PlaywrightFactory.StartAsync();
    }

    [AfterTestRun]
    public static async Task AfterTestRun()
    {
        await PlaywrightFactory.StopAsync();
    }
}
