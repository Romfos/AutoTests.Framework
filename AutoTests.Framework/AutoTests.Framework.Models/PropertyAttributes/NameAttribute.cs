namespace AutoTests.Framework.Models.PropertyAttributes
{
    public class NameAttribute : PropertyAttribute
    {
        public string Value { get; }

        public NameAttribute(string value)
        {
            Value = value;
        }
    }
}