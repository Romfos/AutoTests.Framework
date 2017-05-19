using System;

namespace AutoTests.Framework.Core.Exceptions
{
    public class AssertException : Exception
    {
        public AssertException(string message) : base(message)
        {
        }
    }
}