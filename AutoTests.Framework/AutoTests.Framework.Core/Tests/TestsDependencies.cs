using BoDi;

namespace AutoTests.Framework.Core.Tests
{
    public class TestsDependencies : Dependencies
    {
        public TestsDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public Assert Assert => ObjectContainer.Resolve<Assert>();

        public T GetDependencies<T>()
            where T : Dependencies
        {
            return ObjectContainer.Resolve<T>();
        }

        public override void Setup()
        {
        }
    }
}