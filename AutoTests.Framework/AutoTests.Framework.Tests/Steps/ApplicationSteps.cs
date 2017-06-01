using TechTalk.SpecFlow;

namespace AutoTests.Framework.Tests.Steps
{
    [Binding]
    public class ApplicationSteps
    {
        private readonly Application application;

        public ApplicationSteps(Application application)
        {
            this.application = application;
        }

        [BeforeScenario]
        public void Setup()
        {
            application.Register();
            application.Configure();
        }
    }
}