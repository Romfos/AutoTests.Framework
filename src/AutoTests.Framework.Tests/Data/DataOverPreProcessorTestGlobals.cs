using AutoTests.Framework.Data;

namespace AutoTests.Framework.Tests.Data;

public class DataOverPreProcessorTestGlobals
{
    private readonly DataHub dataHub;

    public dynamic Data => dataHub.CreateDynamicObject();

    public DataOverPreProcessorTestGlobals(DataHub dataHub)
    {
        this.dataHub = dataHub;
    }
}
