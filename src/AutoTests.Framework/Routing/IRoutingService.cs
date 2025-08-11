namespace AutoTests.Framework.Routing;

public interface IRoutingService
{
    T GetComponent<T>(string path) where T : class;
}
