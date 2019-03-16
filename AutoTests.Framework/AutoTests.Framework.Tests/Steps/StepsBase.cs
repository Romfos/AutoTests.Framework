namespace AutoTests.Framework.Tests.Steps
{
    public abstract class StepsBase
    {
        protected readonly Application application;

        protected StepsBase(Application application)
        {
            this.application = application;
        }
    }
}