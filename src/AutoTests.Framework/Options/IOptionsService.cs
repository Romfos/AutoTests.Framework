namespace AutoTests.Framework.Options;

public interface IOptionsService
{
    T GetOptions<T>(string path);
}
