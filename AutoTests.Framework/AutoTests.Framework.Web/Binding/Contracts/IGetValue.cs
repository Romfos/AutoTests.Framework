namespace AutoTests.Framework.Web.Binding.Contracts
{
    public interface IGetValue<T> : IContract
    {
        T GetValue();
    }
}