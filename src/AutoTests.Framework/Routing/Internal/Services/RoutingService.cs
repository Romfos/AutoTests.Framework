using AutoTests.Framework.Routing.Internal.Exceptions;
using AutoTests.Framework.Routing.Internal.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AutoTests.Framework.Routing.Internal.Services;

internal sealed class RoutingService(IServiceProvider serviceProvider) : IRoutingService
{
    public T GetComponent<T>(string path) where T : class
    {
        path = path.GetPathKey();
        var component = serviceProvider.GetKeyedService<IComponent>(path);

        if (component == null)
        {
            throw new UnableToLocateComponentException(path);
        }

        if (component is not T contract)
        {
            throw new UnsupportedContractException(path, typeof(T).Name);
        }

        return contract;
    }
}
