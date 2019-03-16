using System.Collections.Generic;
using System.Linq;

namespace AutoTests.Framework.PageObjects.Provider
{
    public class PageObjectQuery
    {
        public string PrimaryPageName { get; }

        public string[] NestedPageObjectNames { get; }

        public PageObjectQuery(string query)
        {
            var parts = GetQueryParts(query);
            PrimaryPageName = parts[0];
            NestedPageObjectNames = parts.Skip(1).ToArray();
        }

        private List<string> GetQueryParts(string query)
        {
            return query.Split('>').Select(x => x.Trim()).ToList();
        }
    }
}