using AutoTests.Framework.Models.PropertyAttributes;
using AutoTests.Framework.PreProcessor.Assets;

namespace AutoTests.Demo.Common.PreProcessor.Assets
{
    public class AttributesAsset : Asset
    {
        public DisabledAttribute Disabled => new DisabledAttribute();
    }
}