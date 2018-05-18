using AutoTests.Framework.Models;
using AutoTests.Framework.Models.Comparator.Results;

namespace AutoTests.Framework.Example.Comparator.Results
{
    public class ExpectedAttributeNotFound : Result
    {
        public PropertyLink Actual { get; }
        public string AttributeName { get; }

        public ExpectedAttributeNotFound(PropertyLink actual, string attributeName)
        {
            Actual = actual;
            AttributeName = attributeName;
        }

        public override string ToString()
        {
            return $"Attriubte '{AttributeName}' wasn't found for property {Actual.Name}";
        }
    }
}