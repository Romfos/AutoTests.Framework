namespace AutoTests.Framework.PageObjects.Contracts.PageObjectContracts
{
    public interface ISetValueContract<T> : IContract
    {
        void SetValue(T value);
    }
}