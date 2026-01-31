using AutoTests.Framework.Playwright.AI.Resources;

namespace AutoTests.Framework.Playwright.AI.Resources.Internal;

internal sealed class DynamicDataService(dynamic data) : IDynamicDataService
{
    public dynamic Data { get; } = data;
}
