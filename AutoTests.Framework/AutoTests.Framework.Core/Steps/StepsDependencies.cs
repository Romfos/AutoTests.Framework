using BoDi;

namespace AutoTests.Framework.Core.Steps
{
    public class StepsDependencies : Dependencies
    {
        public StepsDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public Assert Assert => ObjectContainer.Resolve<Assert>();

        public T GetDependencies<T>()
            where T : Dependencies
        {
            return ObjectContainer.Resolve<T>();
        }

        protected override void CustomRegister()
        {
            
        }

        protected override void CustomConfigure()
        {
            
        }
    }
}