namespace AutoTests.Framework.Components.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public sealed class RouteAttribute(string name) : Attribute
{
    public string Name { get; } = name;
}
