using System;
using System.Collections.Generic;

namespace AutoTests.Framework.Core
{
    public interface IContainer
    {
        object Resolve(Type type);
        object Create(Type type);
        IEnumerable<Type> GetSubTypes(Type parentType);
    }
}
