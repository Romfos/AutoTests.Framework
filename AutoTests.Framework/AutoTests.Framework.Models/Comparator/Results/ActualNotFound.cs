namespace AutoTests.Framework.Models.Comparator.Results
{
    public class ActualNotFound : Result
    {
        public PropertyLink Expected { get; }

        public ActualNotFound(PropertyLink expected)
        {
            Expected = expected;
        }

        public override string ToString()
        {
            return $"Proeprty '{Expected.Name}' not found in actual model";
        }
    }
}