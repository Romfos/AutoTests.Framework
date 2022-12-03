using System;

namespace AutoTests.Framework.Components.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public sealed class SelectorAttribute : Attribute
{
    public string Value { get; }

    public SelectorAttribute(string name)
    {
        Value = name;
    }
}
