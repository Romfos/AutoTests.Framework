namespace BootstrapTests.Steps
{
    public abstract class StepsBase
    {
        protected Application Application { get; }

        protected StepsBase(Application application)
        {
            Application = application;
        }
    }
}
