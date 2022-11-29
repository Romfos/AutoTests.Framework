using AutoTests.Framework.Components.Routes;
using System;

namespace AutoTests.Framework.Components.Specflow.Extensions;

    public static class ComponentRouterExtensions
    {
        public static T ResolveContract<T>(this ComponentRouter componentRouter, string query)
            where T : class
        {
            var component = componentRouter.Resolve(RouterRequest.FromQuery(query)) as T;
            if (component == null)
            {
                throw new Exception($"Component must implement '{typeof(T).Name}' contract");
            }
            return component;
        }
    }
