using AutoTests.Framework.Models;
using AutoTests.Framework.Models.Attributes;

namespace AutoTests.Framework.Tests.Models.EnabledDisableAttributeTest;

public class EnabledDisableAttributeTestModel : Model
{
    [Disabled]
    public int Value { get; set; }
}
