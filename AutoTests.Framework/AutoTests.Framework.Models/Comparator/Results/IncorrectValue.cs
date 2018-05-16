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
            return $"Property '{Expected.Name}' contains incorrect value. " +
                   $"Expected: '{GetTextValue(Expected)}'. " +
                   $"Actual: '{GetTextValue(Actual)}'";
        }

        private string GetTextValue(PropertyLink propertyLink)
        {
            return propertyLink.Value?.ToString() ?? "null";
        }
    }
}