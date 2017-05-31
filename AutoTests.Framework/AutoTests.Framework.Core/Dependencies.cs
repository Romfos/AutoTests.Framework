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

        protected GlobalDependencies Global => ObjectContainer.Resolve<GlobalDependencies>();
        
        public void Register()
        {
            if (!registered)
            {
                registered = true;

                Global.Register();
                Global.AddAssembly(GetType().Assembly);

                RegisterCustomTypes();
            }
        }

        public void Configure()
        {
            if (!configured)
            {
                configured = true;
                Global.Configure();
                ConfigureDependencies();
            }
        }

        protected abstract void RegisterCustomTypes();

        protected abstract void ConfigureDependencies();
    }
}