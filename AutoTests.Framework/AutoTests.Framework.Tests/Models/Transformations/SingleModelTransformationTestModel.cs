using AutoTests.Framework.Models;
using AutoTests.Framework.Models.Attributes;

namespace AutoTests.Framework.Tests.Models.Transformations;

public class SingleModelTransformationTestModel : Model
{
    [Name("Value1")]
    public int Data { get; set; }

    public int Value2 { get; set; }

    public int Value3 { get; set; }
}
