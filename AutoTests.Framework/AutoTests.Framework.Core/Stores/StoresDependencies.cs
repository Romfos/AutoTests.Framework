using BoDi;

namespace AutoTests.Framework.Core.Stores
{
    public class StoresDependencies : Dependencies
    {
        public StoresDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public KeyValueStore KeyValueStore => ObjectContainer.Resolve<KeyValueStore>();

        protected override void RegisterCustomTypes()
        {
            
        }

        protected override void ConfigureDependencies()
        {
            
        }
    }
}