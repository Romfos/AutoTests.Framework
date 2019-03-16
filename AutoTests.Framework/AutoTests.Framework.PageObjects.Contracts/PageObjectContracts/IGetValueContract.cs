namespace AutoTests.Framework.PageObjects.Contracts.PageObjectContracts
{
    public interface IGetValueContract<T> : IContract
    {
        T GetValue();
    }
}