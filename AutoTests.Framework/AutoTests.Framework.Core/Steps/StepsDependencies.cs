using BoDi;

namespace AutoTests.Framework.Core.Steps
{
    public class StepsDependencies : Dependencies
    {
        public StepsDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public Assert Assert => ObjectContainer.Resolve<Assert>();
    }
}