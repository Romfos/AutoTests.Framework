namespace AutoTests.Framework.Pages;

[AttributeUsage(AttributeTargets.Property)]
public sealed class RouteAttribute(string name) : Attribute
{
    public string Name { get; } = name;
}
