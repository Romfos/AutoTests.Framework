using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace AutoTests.Framework.TestData.TestDataProviders.FileResoruceProviders
{
    public abstract class JsonFileResoruceProviderBase : FileResoruceProviderBase
    {
        private readonly TestDataDependencies dependencies;

        protected JsonFileResoruceProviderBase(TestDataDependencies dependencies)
        {
            this.dependencies = dependencies;
        }

        protected override IEnumerable<KeyValuePair<string, string>> ParseResource(FileInfo file, string name)
        {
            var json = File.ReadAllText(file.FullName);
            var jObject = JObject.Parse(json);
            return LoadResources(jObject, name);
        }

        private IEnumerable<KeyValuePair<string, string>> LoadResources(JObject jObject, string resourceName)
        {
            return jObject.Descendants()
                .OfType<JValue>()
                .Select(x => new KeyValuePair<string, string>($"{resourceName}.{x.Path}", x.ToString()));
        }
    }
}