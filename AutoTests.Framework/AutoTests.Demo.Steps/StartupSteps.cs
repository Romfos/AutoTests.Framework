using AutoTests.Demo.Common;
using AutoTests.Framework.Core.Steps;
using TechTalk.SpecFlow;

namespace AutoTests.Demo.Steps
{
    [Binding]
    public class StartupSteps : StepsBase
    {
        private readonly Application application;
        private bool activated;
        
        public StartupSteps(Application application) : base(application.Steps)
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