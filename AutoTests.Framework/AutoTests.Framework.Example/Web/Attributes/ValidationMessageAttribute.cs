using AutoTests.Framework.Models.PropertyAttributes;

namespace AutoTests.Framework.Example.Web.Attributes
{
    public class ValidationMessageAttribute : PropertyAttribute
    {
        public string Message { get; }

        public ValidationMessageAttribute(string message)
        {
            Message = message;
        }
    }
}