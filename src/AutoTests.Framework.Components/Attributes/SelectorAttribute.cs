namespace AutoTests.Framework.Components.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public sealed class SelectorAttribute(string name) : Attribute
{
    public string Value { get; } = name;
}
