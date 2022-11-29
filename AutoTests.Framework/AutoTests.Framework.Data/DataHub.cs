using System.Collections.Generic;
using System.Linq;

namespace AutoTests.Framework.Data;

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
            var dynamicDataObjectBuilder = new DynamicDataObjectBuilder();
            var dynamicObject = dictionary
                .Aggregate(dynamicDataObjectBuilder, (builder, pair) => builder.Add(pair.Key, pair.Value))
                .ToDynamic();
            return dynamicObject;
        }
    }
