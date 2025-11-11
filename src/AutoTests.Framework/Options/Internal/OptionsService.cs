using AutoTests.Framework.Routing.Internal.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AutoTests.Framework.Options.Internal;

internal sealed class OptionsService(IServiceProvider serviceProvider) : IOptionsService
{
    public T GetOptions<T>(string path)
    {
        path = path.GetPathKey();
        if (serviceProvider.GetKeyedService<IComponentOptions>(path) is not { } options)
        {
            throw new Exception($"Invalid options for '{path}'");
        }

        return options.Get<T>();
    }
}
