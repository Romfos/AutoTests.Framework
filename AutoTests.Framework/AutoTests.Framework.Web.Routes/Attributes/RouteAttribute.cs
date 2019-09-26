using System;

namespace AutoTests.Framework.Web.Routes.Attributes
{
    public class RouteAttribute : Attribute
    {
        public string Route { get; set; }

        public RouteAttribute(string route)
        {
            Route = route;
        }
    }
}
