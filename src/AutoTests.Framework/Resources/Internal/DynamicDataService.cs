namespace AutoTests.Framework.Resources.Internal;

internal sealed class DynamicDataService(dynamic data) : IDynamicDataService
{
    public dynamic Data { get; } = data;
}
