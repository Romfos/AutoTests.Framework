using AutoTests.Framework.Models;

namespace AutoTests.Framework.Tests.Models.NestedModelsTest;

public class NestedModelsTestTopModel : Model
{
    public int Value1 { get; } = 1;

    public NestedModelsTestNestedModel NestedModel { get; private set; }
}
