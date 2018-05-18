using AutoTests.Framework.Models;
using AutoTests.Framework.Models.Comparator.Results;

namespace AutoTests.Framework.Example.Comparator.Results
{
    public class IncorrectValidationMessage : Result
    {
        public PropertyLink Expected { get; }

        public string ExpectedMesssage { get; }
        public string ActualMesssage { get; }

        public IncorrectValidationMessage(PropertyLink expected, string expectedMesssage, string actualMesssage)
        {
            Expected = expected;
            ExpectedMesssage = expectedMesssage;
            ActualMesssage = actualMesssage;
        }

        public override string ToString()
        {
            return $"Property '{Expected.Name}' contains incorrect validation message. " +
                   $"Expected: '{ExpectedMesssage}'. " +
                   $"Actual: '{ActualMesssage}'";
        }
    }
}