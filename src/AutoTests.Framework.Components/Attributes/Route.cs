using System;

namespace AutoTests.Framework.Components.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public sealed class Route : Attribute
{
    public string Name { get; }

    public Route(string name)
    {
        Name = name;
    }
}
