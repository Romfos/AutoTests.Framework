using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace AutoTests.Framework.Data;

public class DynamicDataObjectBuilder
{
    private readonly ExpandoObject root;

    public DynamicDataObjectBuilder()
    {
        root = new ExpandoObject();
    }

    public DynamicDataObjectBuilder Add(DataPath path, object value)
    {
        var node = GetOrCreateNode(path);
        var name = path.Nodes.Last();
        node[name] = value;
        return this;
    }

    private IDictionary<string, object> GetOrCreateNode(DataPath path)
    {
        var current = root as IDictionary<string, object>;
        foreach (var node in path.Nodes.Take(path.Nodes.Length - 1))
        {
            if (current.ContainsKey(node))
            {
                current = (IDictionary<string, object>)current[node];
            }
            else
            {
                var next = new ExpandoObject();
                current.Add(node, next);
                current = next as IDictionary<string, object>;
            }
        }
        return current;
    }

    public dynamic ToDynamic()
    {
        return root;
    }
}
