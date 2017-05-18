namespace AutoTests.Framework.Web.Binding.Contracts
{
    public interface ISetValue<T> : IContract
    {
        void SetValue(T value);
    }
}