using BoDi;

namespace AutoTests.Framework.Core
{
    public abstract class Dependencies
    {
        private bool registered;
        private bool configured;

        protected ObjectContainer ObjectContainer { get; }

        protected Dependencies(ObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
        }

        protected CoreDependencies Core => ObjectContainer.Resolve<CoreDependencies>();
        
        public void Register()
        {
            if (!registered)
            {
                registered = true;

                Core.Register();
                Core.AddAssembly(GetType().Assembly);

                RegisterCustomTypes();
            }
        }

        public void Configure()
        {
            if (!configured)
            {
                configured = true;
                Core.Configure();
                ConfigureDependencies();
            }
        }

        protected abstract void RegisterCustomTypes();

        protected abstract void ConfigureDependencies();
    }
}