using AutoTests.Framework.Data;

namespace AutoTests.Framework.Tests.PreProcessor
{
    public partial class DataTests
    {
        public class DataOverPreProcessorTestGlobals
        {
            private readonly DataHub dataHub;

            public dynamic Data => dataHub.CreateDynamicObject();

            public DataOverPreProcessorTestGlobals(DataHub dataHub)
            {
                this.dataHub = dataHub;
            }
        }
    }
}
