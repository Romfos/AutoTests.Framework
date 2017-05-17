using System;

namespace AutoTests.Framework.Core.Exceptions
{
    public class ConstraintException : Exception
    {
        public ConstraintException(string message) : base(message)
        {
        }
    }
}