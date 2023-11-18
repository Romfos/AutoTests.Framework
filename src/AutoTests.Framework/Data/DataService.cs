namespace AutoTests.Framework.Data;

public sealed class DataService(dynamic data)
{
    public dynamic Data { get; } = data;
}
