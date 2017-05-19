using BoDi;

namespace AutoTests.Framework.Core.Tests
{
    public class TestsDependencies : Dependencies
    {
        public TestsDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public Assert Assert => ObjectContainer.Resolve<Assert>();

        public override void Setup()
        {
        }
    }
}