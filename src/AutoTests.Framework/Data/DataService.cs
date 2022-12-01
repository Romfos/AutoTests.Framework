namespace AutoTests.Framework.Data;

internal sealed class DataService : IDataService
{
    public dynamic Data { get; }

    public DataService(dynamic data)
    {
        Data = data;
    }
}
