using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoTests.Framework.Core
{
    public class AssemblyPool
    {
        public List<Assembly> Assemblies { get; } = new List<Assembly>();

        public void Upsert(Assembly assembly)
        {
            if (Assemblies.All(x => x != assembly))
            {
                Assemblies.Add(assembly);
            }
        }
    }
}