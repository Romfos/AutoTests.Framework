using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BoDi;

namespace AutoTests.Framework.Core
{
    public abstract class Dependencies
    {
        private bool configured;
        private bool registered;

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

                RegisterDependencies();
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

        private void RegisterDependencies()
        {
            foreach (var dependency in GetDependencies())
            {
                dependency.Register();
            }
            OnDependenciesRegistered();
        }

        private void ConfigureDependencies()
        {
            foreach (var dependency in GetDependencies())
            {
                dependency.Configure();
            }
            OnDependenciesConfigured();
        }

        private IEnumerable<Dependencies> GetDependencies()
        {
            return GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(x => x.CanRead && x.PropertyType.IsSubclassOf(typeof(Dependencies)))
                .Select(x => (Dependencies)x.GetValue(this));
        }

        protected virtual void OnDependenciesRegistered()
        {

        }

        protected virtual void OnDependenciesConfigured()
        {

        }
    }
}