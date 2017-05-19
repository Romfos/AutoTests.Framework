namespace AutoTests.Framework.Models.Comparator.Results
{
    public class IncorrectValue : Result
    {
        public PropertyLink Expected { get; }
        public PropertyLink Actual { get; }

        public IncorrectValue(PropertyLink expected, PropertyLink actual)
        {
            Expected = expected;
            Actual = actual;
        }

        public override string ToString()
        {
            return $"Property '{Expected.Name}' contain incorrect value. " +
                   $"Expected: '{Expected.Value}'. " +
                   $"Actual: '{Actual.Value}'";
        }
    }
}