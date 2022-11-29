using System;

namespace AutoTests.Framework.Core.Exceptions;

    public class AutoTestFrameworkException : Exception
    {
        public AutoTestFrameworkException(string message) : base(message)
        {
        }
    }
