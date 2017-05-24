namespace AutoTests.Framework.Core.Steps
{
    public abstract class StepsBase
    {
        protected Assert Assert { get; }

        protected StepsBase(StepsDependencies dependencies)
        {
            Assert = dependencies.Assert;
        }
    }
}