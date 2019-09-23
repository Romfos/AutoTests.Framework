using System;
using System.Collections.Generic;

namespace AutoTests.Framework.Core
{
    public interface IContainer
    {
        object Resolve(Type type);
        object Create(Type type);        
        void Register<TInterface>(object implementation);
        void Register<TInterface, TImplementation>() where TImplementation : class, TInterface;
        IEnumerable<Type> GetSubTypes(Type parentType);
    }
}
