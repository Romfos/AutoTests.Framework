using AutoTests.Framework.Resources;

namespace Bootstrap.Tests;

public sealed class CSharpExpressions(IDynamicDataService dynamicDataService)
{
    public dynamic Data { get; } = dynamicDataService.Data;
}
