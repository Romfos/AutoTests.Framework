using BoDi;

namespace AutoTests.Framework.Core.Stores
{
    public class StoresDependencies : Dependencies
    {
        public StoresDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public ObjectStore ObjectStore => ObjectContainer.Resolve<ObjectStore>();

        protected override void CustomRegister()
        {
            
        }

        protected override void CustomConfigure()
        {
            
        }
    }
}