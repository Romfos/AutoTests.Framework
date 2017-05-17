namespace AutoTests.Framework.Models.Transformations
{
    public class Prototype
    {
        public string Name { get; }
        public string Value { get; }
        public string Attributes { get; }

        public Prototype(string name, string value, string attributes)
        {
            Name = name;
            Value = value;
            Attributes = attributes;
        }
    }
}