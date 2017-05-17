using System;

namespace AutoTests.Framework.Core.Exceptions
{
    public class ClassConstraintException : ConstraintException
    {
        public ClassConstraintException(Type type, string format)
            : base(string.Format(format, type.Name))
        {
        }
    }
}