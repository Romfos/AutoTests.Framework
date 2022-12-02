using AutoTests.Framework.Components.Application;
using AutoTests.Framework.Components.Contracts;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Components;

[Binding]
public sealed class ComponentsSteps
{
    [When(@"click on '([^']*)'")]
    public async Task WhenClickOn(IComponentReference componentReference)
    {
        await componentReference.GetComponent<IClick>().ClickAsync();
    }
}
