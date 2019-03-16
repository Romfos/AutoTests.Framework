using System;

namespace AutoTests.Framework.PageObjects.Attributes
{
    public class LocatorAttribute : Attribute
    {
        public string Value { get; }

        public LocatorAttribute(string value)
        {
            Value = value;
        }
    }
}