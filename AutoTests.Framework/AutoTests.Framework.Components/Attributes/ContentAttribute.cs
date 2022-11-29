using System;

namespace AutoTests.Framework.Components.Attributes;

public class ContentAttribute : Attribute
{
    public string Data { get; }

    public ContentAttribute(string data)
    {
        Data = data;
    }
}
