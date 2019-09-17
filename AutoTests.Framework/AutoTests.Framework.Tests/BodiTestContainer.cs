using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoTests.Framework.Core;
using BoDi;

namespace AutoTests.Framework.Tests
{
    public class BodiTestContainer : IContainer
    {
        private readonly IObjectContainer objectContainer;

        public BodiTestContainer(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        public object Create(Type type)
        {
            var constructor = type.GetConstructors().Single();
            var parametres = constructor.GetParameters().Select(x => objectContainer.Resolve(x.ParameterType)).ToArray();
            return constructor.Invoke(parametres);
        }

        public IEnumerable<Type> GetSubTypes(Type parentType)
        {
            return Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(parentType));
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
