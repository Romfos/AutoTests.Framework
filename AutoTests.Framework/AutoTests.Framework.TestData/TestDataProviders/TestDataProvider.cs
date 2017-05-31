namespace AutoTests.Framework.TestData.TestDataProviders
{
    public abstract class TestDataProvider
    {
        public abstract void LoadResoruces();

        public abstract object GetResoruce(string name);
    }
}