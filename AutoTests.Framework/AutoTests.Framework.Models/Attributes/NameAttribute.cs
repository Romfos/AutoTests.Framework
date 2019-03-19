namespace AutoTests.Framework.Models.Attributes
{
    public class NameAttribute : ModelPropertyAttribute
    {
        public string Value { get; }

        public NameAttribute(string value)
        {
            Value = value;
        }
    }
}