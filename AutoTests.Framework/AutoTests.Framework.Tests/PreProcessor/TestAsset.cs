using AutoTests.Framework.Models.PropertyAttributes;
using AutoTests.Framework.PreProcessor.Infrastructure;

namespace AutoTests.Framework.Tests.PreProcessor
{
    public class TestAsset : Asset
    {
        public NameAttribute Name(string value)
        {
            return new NameAttribute(value);
        }
    }
}