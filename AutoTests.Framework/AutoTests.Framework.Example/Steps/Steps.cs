using AutoTests.Framework.Core.Steps;

namespace AutoTests.Framework.Example.Steps
{
    public abstract class Steps : StepsBase
    {
        protected readonly Application application;

        protected Steps(Application application) : base(application.Steps)
        {
            this.application = application;
        }
    }
}