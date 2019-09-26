using AutoTests.Framework.Core;
using AutoTests.Framework.Web.Routes.Attributes;
using System.Linq;
using System.Reflection;

namespace AutoTests.Framework.Web.Routes
{
    public class ComponentRouter
    {
        private readonly IContainer container;

        public ComponentRouter(IContainer container)
        {
            this.container = container;
        }

        public Component Resolve(string query)
        {
            var routerQuery = new RouterQuery(query);
            var component = ResolveRootComponent(routerQuery);
            foreach(var route in routerQuery.NestedComponentRoutes())
            {
                component = GetNestedComponent(component, route);
            }
            return component;
        }

        private Component ResolveRootComponent(RouterQuery routerQuery)
        {
            return container.GetSubTypes(typeof(Component))
                .Where(x => x.GetCustomAttributes<RouteAttribute>().SingleOrDefault()?.Route == routerQuery.GetRootComponentRoute())
                .Select(x => (Component)container.Resolve(x))
                .Single();
        }

        private Component GetNestedComponent(Component component, string route)
        {
            return component.GetType().GetProperties()
                .Where(x => x.PropertyType.IsSubclassOf(typeof(Component)))
                .Where(x => x.CanRead)
                .Where(x => x.GetCustomAttributes<RouteAttribute>().SingleOrDefault()?.Route == route)
                .Select(x => (Component)x.GetValue(component))
                .Single();
        }
    }
}
