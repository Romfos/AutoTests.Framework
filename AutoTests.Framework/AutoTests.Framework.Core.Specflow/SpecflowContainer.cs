using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoTests.Framework.Core.Specflow
{
    public class SpecflowContainer : IContainer
    {
        private readonly IObjectContainer objectContainer;
        private readonly List<Assembly> assemblies;

        public SpecflowContainer(IObjectContainer objectContainer, List<Assembly> assemblies)
        {
            this.objectContainer = objectContainer;
            this.assemblies = assemblies;
        }

        public object Create(Type type)
        {
            var constructor = type.GetConstructors().Single();
            var parametres = constructor.GetParameters().Select(x => objectContainer.Resolve(x.ParameterType)).ToArray();
            return constructor.Invoke(parametres);
        }

        public IEnumerable<Type> GetSubTypes(Type parentType)
        {
            return assemblies.SelectMany(x => x.GetTypes()).Where(x => x.IsSubclassOf(parentType));
        }

        public void Register(Type interfaceType, Type implementationType)
        {
            objectContainer.RegisterInstanceAs(objectContainer.Resolve(implementationType), interfaceType);
        }

        public void Register<TInterface, TImplementation>()
            where TImplementation : class, TInterface
        {
            objectContainer.RegisterTypeAs<TImplementation, TInterface>();
        }

        public void Register<TInterface, TImplementation>(TImplementation implementation)
            where TImplementation : class, TInterface
        {
            objectContainer.RegisterInstanceAs(implementation, typeof(TInterface));
        }

        public object Resolve(Type type)
        {
            return objectContainer.Resolve(type);
        }
    }
}
