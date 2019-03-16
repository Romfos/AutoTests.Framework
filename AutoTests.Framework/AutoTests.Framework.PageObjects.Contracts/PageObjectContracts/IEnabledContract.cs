namespace AutoTests.Framework.PageObjects.Contracts.PageObjectContracts
{
    public interface IEnabledContract : IContract
    {
        bool Enabled { get; }
    }
}