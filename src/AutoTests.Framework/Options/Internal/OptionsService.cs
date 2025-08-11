using AutoTests.Framework.Routing.Internal.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AutoTests.Framework.Options.Internal;

internal sealed class OptionsService(IServiceProvider serviceProvider) : IOptionsService
{
    public T GetOptions<T>(string path)
    {
        path = path.GetPathKey();
        if (serviceProvider.GetKeyedService<ComponentOptions>(path)?.Value is not T value)
        {
            throw new Exception($"Invalid options for '{path}'");
        }

        return value;
    }
}
