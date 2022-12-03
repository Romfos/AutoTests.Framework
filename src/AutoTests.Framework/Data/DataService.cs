namespace AutoTests.Framework.Data;

public sealed class DataService
{
    public dynamic Data { get; }

    public DataService(dynamic data)
    {
        Data = data;
    }
}
