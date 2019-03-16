using System;

namespace AutoTests.Framework.PageObjects.Provider.Attributes
{
    public class PageObjectNameAttribute : Attribute
    {
        public string Name { get; }

        public PageObjectNameAttribute(string name)
        {
            Name = name;
        }
    }
}