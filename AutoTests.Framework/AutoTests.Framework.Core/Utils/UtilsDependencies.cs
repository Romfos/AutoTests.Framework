using BoDi;

namespace AutoTests.Framework.Core.Utils
{
    public class UtilsDependencies : Dependencies
    {
        public UtilsDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public ResourceUtils Resources => ObjectContainer.Resolve<ResourceUtils>();

        protected override void CustomRegister()
        {
            
        }

        protected override void CustomConfigure()
        {
            
        }
    }
}