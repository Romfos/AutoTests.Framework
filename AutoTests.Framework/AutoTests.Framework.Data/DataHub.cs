using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace AutoTests.Framework.Data
{
    public class DataHub
    {
        private readonly Dictionary<DataPath, object> dictionary;

        public DataHub()
        {
            dictionary = new Dictionary<DataPath, object>();
        }

        public void Add(DataPath path, object value)
        {
            dictionary.Add(path, value);
        }

        public object Get(DataPath path)
        {
            return dictionary[path];
        }

        public dynamic CreateDynamicObject()
        {
            var root = new ExpandoObject();
            foreach(var keyValuePair in dictionary)
            {
                var current = root as IDictionary<string, object>;
                foreach (var node in keyValuePair.Key.Nodes.Take(keyValuePair.Key.Nodes.Length - 1))
                {
                    if (current.ContainsKey(node))
                    {
                        current = (IDictionary<string, object>) current[node];
                    }
                    else
                    {
                        var expandoObject = new ExpandoObject();
                        current.Add(node, expandoObject);
                        current = expandoObject;
                    }
                }
                current[keyValuePair.Key.Nodes.Last()] = keyValuePair.Value;
            }
            return root;
        }
    }
}
