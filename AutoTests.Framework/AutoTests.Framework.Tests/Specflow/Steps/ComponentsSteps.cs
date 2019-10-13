using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoTests.Framework.Components.Routes;
using AutoTests.Framework.Tests.Web;

namespace AutoTests.Framework.Tests.Specflow.Steps
{
    [Binding]
    public class ComponentsSteps
    {
        private readonly ComponentRouter componentRouter;

        public ComponentsSteps(ComponentRouter componentRouter)
        {
            this.componentRouter = componentRouter;
        }

        [Then(@"component '(.*)' should pass internal check")]
        public void ThenComponentShouldPassInternalCheck(string query)
        {
            var component = componentRouter.Resolve(RouterRequest.FromQuery(query)) as IInternalComponentStatus;
            Assert.IsTrue(component.InternalComponentStatus);
        }
    }
}
