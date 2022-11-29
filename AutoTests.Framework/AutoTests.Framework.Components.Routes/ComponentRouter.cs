using AutoTests.Framework.Core;
using AutoTests.Framework.Components.Routes.Attributes;
using System.Linq;
using System.Reflection;
using AutoTests.Framework.Core.Exceptions;
using AutoTests.Framework.Components.Utils;

namespace AutoTests.Framework.Components.Routes;

    public class ComponentRouter
    {
        private readonly IContainer container;
        private readonly ComponentReflectionUtils componentReflectionUtils;

        public ComponentRouter(IContainer container, ComponentReflectionUtils componentReflectionUtils)
        {
            this.container = container;
            this.componentReflectionUtils = componentReflectionUtils;
        }

        public Component Resolve(RouterRequest request)
        {
            var component = ResolveRootComponent(request);
            foreach(var node in request.GetNestedComponentRoutes())
            {
                component = GetNestedComponent(component, node);
            }
            return component;
        }

        private Component ResolveRootComponent(RouterRequest request)
        {
            var rootComponentRoute = request.GetRootComponentRoute();

            var component = container.GetSubTypes(typeof(Component))
                .Where(x => x.GetCustomAttributes<RouteAttribute>().SingleOrDefault()?.Route == rootComponentRoute)
                .Select(x => (Component)container.Resolve(x))
                .SingleOrDefault();

            if(component == null)
            {
                throw new AutoTestFrameworkException("Router have not been able to find a component");
            }

            return component;
        }

        private Component GetNestedComponent(Component component, string route)
        {
            var nestedComponent = componentReflectionUtils.GetComponentProperties(component)
                .Where(x => x.GetCustomAttributes<RouteAttribute>().SingleOrDefault()?.Route == route)
                .Select(x => (Component)x.GetValue(component)!)
                .SingleOrDefault();

            if (nestedComponent == null)
            {
                throw new AutoTestFrameworkException("Router have not been able to find a nested component");
            }

            return nestedComponent;
        }
    }
