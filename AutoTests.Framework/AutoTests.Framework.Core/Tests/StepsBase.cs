namespace AutoTests.Framework.Core.Tests
{
    public abstract class StepsBase
    {
        protected Assert Assert { get; }

        protected StepsBase(TestsDependencies dependencies)
        {
            Assert = dependencies.Assert;
        }
    }
}