namespace AutoTests.Framework.Components.Contracts;

public interface IEnabled
{
    Task<bool> IsEnabledAsync();
}
