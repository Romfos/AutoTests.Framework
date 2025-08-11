using AutoTests.Framework.Options;
using AutoTests.Framework.Options.Internal;
using AutoTests.Framework.Pages;
using AutoTests.Framework.Resources;
using AutoTests.Framework.Resources.Internal;
using AutoTests.Framework.Routing;
using AutoTests.Framework.Routing.Internal.Extensions;
using AutoTests.Framework.Routing.Internal.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace AutoTests.Framework;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AutoTestsFramework(this IServiceCollection services)
    {
        services.TryAddSingleton<IOptionsService, OptionsService>();
        services.TryAddScoped<IRoutingService, RoutingService>();

        services.SourceGeneratedGherkinSteps();

        return services;
    }

    [RequiresUnreferencedCode("This method is reflection based and not Trimmng and AOT firendly")]
    [RequiresDynamicCode("This method is reflection based and not Trimmng and AOT firendly")]
    public static IServiceCollection DynamicResourcesData(this IServiceCollection services, Assembly[] assemblies)
    {
        services.TryAddSingleton<IDynamicDataService>(_ => new DynamicDataService(new JsonDataLoader().Load(assemblies)));

        return services;
    }

    public static ComponentRoutingBuilder Component<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TComponent>(
        this IServiceCollection services, string path) where TComponent : class, IComponent
    {
        return services.Component(path, typeof(TComponent));
    }

    public static ComponentRoutingBuilder Component(this IServiceCollection services, string path,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type componentType)
    {
        path = path.GetPathKey();
        services.AddKeyedTransient(typeof(IComponent), path, componentType);
        return new(services, path);
    }

    public static IServiceCollection ComponentOptions(this IServiceCollection services, string path, object value)
    {
        path = path.GetPathKey();
        services.AddKeyedSingleton(path, (_, _) => new ComponentOptions(value));
        return services;
    }

    [RequiresUnreferencedCode("This method is reflection based and not Trimmng and AOT firendly")]
    public static IServiceCollection Page<T>(this IServiceCollection services, string? prefix = null) where T : class
    {
        CollectComponentsAndOptions(services, prefix, typeof(T));

        return services;
    }

    [RequiresUnreferencedCode("This method is reflection based and not Trimmng and AOT firendly")]
    private static void CollectComponentsAndOptions(IServiceCollection services, string? prefix, Type type)
    {
        foreach (var property in type.GetProperties())
        {
            if (property.GetCustomAttribute<RouteAttribute>() is RouteAttribute routeAttribute)
            {
                var path = prefix == null ? routeAttribute.Name : $"{prefix}>{routeAttribute.Name}";

                if (typeof(IComponent).IsAssignableFrom(property.PropertyType))
                {
                    services.Component(path, property.PropertyType);

                    if (property.GetCustomAttribute<OptionsAttribute>() is OptionsAttribute optionsAttribute)
                    {
                        services.ComponentOptions(path, optionsAttribute.Value);
                    }
                }
                else
                {
                    CollectComponentsAndOptions(services, path, property.PropertyType);
                }
            }
        }
    }
}
