using System;

namespace AutoTests.Framework.Web.Attributes
{
    public class LocatorAttribute : Attribute
    {
        public string Locator { get; }

        public LocatorAttribute(string locator)
        {
            Locator = locator;
        }
    }
}