using System;

namespace AutoTests.Framework.Web.Attributes
{
    public class ContentAttribute : Attribute
    {
        public string Data { get; }

        public ContentAttribute(string data)
        {
            Data = data;
        }
    }
}
