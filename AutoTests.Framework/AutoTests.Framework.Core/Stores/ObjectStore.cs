using System.Collections.Generic;

namespace AutoTests.Framework.Core.Stores
{
    public class ObjectStore
    {
        private readonly Dictionary<string, object> dictionary = new Dictionary<string, object>();

        public object this[string key]
        {
            get { return dictionary[key]; }
            set
            {
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key] = value;
                }
                else
                {
                    dictionary.Add(key, value);
                }
            }
        }

        public T Get<T>(string key)
        {
            return (T) dictionary[key];
        }
    }
}