using AutoTests.Framework.Playwright.AI.Resources;

namespace Bootstrap.Tests.AI;

public sealed class CSharpExpressions(IDynamicDataService dynamicDataService)
{
    public dynamic Data { get; } = dynamicDataService.Data;
}
