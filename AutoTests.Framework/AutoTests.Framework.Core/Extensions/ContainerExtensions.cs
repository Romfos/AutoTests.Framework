namespace AutoTests.Framework.Core.Extensions;

    public static class ContainerExtensions
    {
        public static T Resolve<T>(this IContainer container)
        {
            return (T) container.Resolve(typeof(T));
        }
    }
