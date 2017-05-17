using System;

namespace AutoTests.Framework.Models.Exceptions
{
    public class TransformationException : Exception
    {
        public TransformationException(string message) : base(message)
        {
        }
    }
}