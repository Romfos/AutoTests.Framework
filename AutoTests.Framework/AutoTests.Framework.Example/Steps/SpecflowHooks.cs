using TechTalk.SpecFlow;

namespace AutoTests.Framework.Example.Steps
{
    [Binding]
    public class SpecflowHooks
    {
        private readonly Application application;

        public SpecflowHooks(Application application)
        {
            this.application = application;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            application.Register();
            application.Configure();
        }
    }
}