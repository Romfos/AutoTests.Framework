using System;

namespace AutoTests.Framework.Components.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public sealed class RouteAttribute : Attribute
{
    public string Name { get; }

    public RouteAttribute(string name)
    {
        Name = name;
    }
}
