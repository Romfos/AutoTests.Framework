using System.Collections.Generic;
using System.Linq;

namespace AutoTests.Framework.Web.Routes
{
    public class RouterQuery
    {
        private readonly List<string> parts;

        public RouterQuery(string path)
        {
            parts = path.Split('/').Select(x => x.Trim()).ToList();
        }

        public string GetRootComponentRoute()
        {
            return parts.First();
        }

        public IEnumerable<string> NestedComponentRoutes()
        {
            return parts.Skip(1);
        }
    }
}
