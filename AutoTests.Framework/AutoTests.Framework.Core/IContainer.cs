using System;
using System.Collections.Generic;

namespace AutoTests.Framework.Core;

    public interface IContainer
    {
        object Resolve(Type type);
        object Create(Type type);
        void Register<TInterface, TImplementation>() where TImplementation : class, TInterface;
        void Register<TInterface>(TInterface implementation) where TInterface : class;
        IEnumerable<Type> GetSubTypes(Type parentType);
    }
