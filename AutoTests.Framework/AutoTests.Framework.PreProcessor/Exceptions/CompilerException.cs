using System;

namespace AutoTests.Framework.PreProcessor.Exceptions
{
    public class CompilerException : Exception
    {
        public CompilerException(string message) : base(message)
        {
        }
    }
}