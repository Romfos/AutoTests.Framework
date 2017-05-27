using BoDi;

namespace AutoTests.Framework.Core.Utils
{
    public class UtilsDependencies : Dependencies
    {
        public UtilsDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public ResourceUtils Resources => ObjectContainer.Resolve<ResourceUtils>();

        protected override void RegisterCustomTypes()
        {
            
        }

        protected override void ConfigureDependencies()
        {
            
        }
    }
}