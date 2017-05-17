using AutoTests.Demo.Common;
using TechTalk.SpecFlow;

namespace AutoTests.Demo.Steps
{
    [Binding]
    public class StartupSteps
    {
        private readonly Application application;
        private bool activated;
        
        public StartupSteps(Application application)
        {
            this.application = application;
        }

        [BeforeScenario]
        public void Setup()
        {
            if (activated)
            {
                return;
            }
            application.Setup();
            activated = true;
        }
    }
}