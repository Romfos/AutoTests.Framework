using AutoTests.Framework.Models.PropertyAttributes;
using AutoTests.Framework.PreProcessor.Infrastructure;

namespace AutoTests.Framework.Models.PreProcessor
{
    public class DefaultAttributesAsset : Asset
    {
        public DisabledAttribute Disabled => new DisabledAttribute();
    }
}