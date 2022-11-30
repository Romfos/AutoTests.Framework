using System.Collections.Generic;
using System.Linq;

namespace AutoTests.Framework.Components.Routes;

public class RouterRequest
{
    private readonly string[] routes;

    public RouterRequest(params string[] routes)
    {
        this.routes = routes;
    }

    public static RouterRequest FromQuery(string query, char separator = '>')
    {
        var nodes = query.Split(separator).Select(x => x.Trim()).ToArray();
        return new RouterRequest(nodes);
    }

    public string GetRootComponentRoute()
    {
        return routes.First();
    }

    public IEnumerable<string> GetNestedComponentRoutes()
    {
        return routes.Skip(1);
    }
}
