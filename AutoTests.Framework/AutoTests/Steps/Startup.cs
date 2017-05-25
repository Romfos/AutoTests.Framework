using TechTalk.SpecFlow;

namespace AutoTests.Steps
{
    [Binding]
    public class Startup
    {
        private readonly Application application;

        public Startup(Application application)
        {
            this.application = application;
        }

        [BeforeScenario]
        public void Setup()
        {
            application.Setup();
        }
    }
}