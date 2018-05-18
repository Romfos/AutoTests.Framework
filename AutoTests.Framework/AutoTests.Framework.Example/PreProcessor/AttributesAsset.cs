using AutoTests.Framework.Example.Web.Attributes;
using AutoTests.Framework.PreProcessor.Infrastructure;

namespace AutoTests.Framework.Example.PreProcessor
{
    public class AttributesAsset : Asset
    {
        public ValidationMessageAttribute ValidationMessage(string messsage)
        {
            return new ValidationMessageAttribute(messsage);
        }
    }
}