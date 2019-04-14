using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace AutoTests.Framework.Configuration
{
    public class ConfigurationProvider
    {
        private readonly Dictionary<string, object> values;

        public ConfigurationProvider(ConfigurationServiceProvider serviceProvider)
        {
            values = new Dictionary<string, object>();
        }

        public void Add(string key, object value)
        {
            values.Add(key, value);
        }

        public T Get<T>(string key)
        {
            return (T)values[key];
        }

        public object Get(string key)
        {
            return values[key];
        }

        public dynamic CreateExpandoObject()
        {
            var expandoObject = new ExpandoObject();
            foreach(var keyValuePair in values)
            {
                SetExpandoObjectValue(expandoObject, keyValuePair.Value, keyValuePair.Key.Split('.').ToList());
            }
            return expandoObject;
        }

        private void SetExpandoObjectValue(ExpandoObject expandoObject, object value, List<string> path)
        {
            var dictionary = expandoObject as IDictionary<string, object>;
            if(path.Count == 1)
            {
                dictionary[path[0]] = value;
            }
            else
            {
                expandoObject = new ExpandoObject();
                SetExpandoObjectValue(expandoObject, value, path.Skip(1).ToList());
                dictionary[path[0]] = expandoObject;
            }
        }
    }
}
