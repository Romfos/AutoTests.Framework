using System.Collections.Generic;
using System.Reflection;
using BoDi;

namespace AutoTests.Framework.Core
{
    public class CoreDependencies : Dependencies
    {
        public List<Assembly> Assemblies { get; } = new List<Assembly>();

        public CoreDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public void AddAssembly(Assembly assembly)
        {
            if (!Assemblies.Contains(assembly))
            {
                Assemblies.Add(assembly);
            }
        }

        protected override void RegisterCustomTypes()
        {
        }

        protected override void ConfigureDependencies()
        {
        }
    }
}