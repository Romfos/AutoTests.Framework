using AutoTests.Framework.Data;

namespace Boostrap.Tests;

public class BoostrapGlobals
{
    private readonly DataHub dataHub;

    public dynamic Data => dataHub.CreateDynamicObject();

    public BoostrapGlobals(DataHub dataHub)
    {
        this.dataHub = dataHub;
    }
}
