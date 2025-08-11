namespace AutoTests.Framework.Contracts;

public interface IEnabled
{
    Task<bool> IsEnabledAsync();
}
