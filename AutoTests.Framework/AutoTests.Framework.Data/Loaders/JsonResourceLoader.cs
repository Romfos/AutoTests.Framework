using AutoTests.Framework.Core.Utils;
using System;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace AutoTests.Framework.Data.Loaders;

    public class JsonResourceLoader
    {
        private readonly EmbeddedResourceUtils embeddedResourceUtils;

        public JsonResourceLoader(EmbeddedResourceUtils embeddedResourceUtils)
        {
            this.embeddedResourceUtils = embeddedResourceUtils;
        }

        public void LoadJsonResource(DataHub dataHub, Assembly assembly, string resourceName, DataPath? basePath = null)
        {
            var content = embeddedResourceUtils.GetLocalEmbeddedResourceText(assembly, resourceName);
            using var jsonDocument = JsonDocument.Parse(content);
            AddJsonElementValuesToDataHub(dataHub, basePath ?? DataPath.Empty, jsonDocument.RootElement);
        }

        public void LoadJsonResources(DataHub dataHub, Assembly assembly, 
            Regex regex, bool includeResourceName = true, DataPath? basePath = null)
        {
            var resourceNames = embeddedResourceUtils.GetLocalEmbeddedResourceNames(assembly, regex);
            foreach(var resourceName in resourceNames)
            {
                var content = embeddedResourceUtils.GetLocalEmbeddedResourceText(assembly, resourceName);
                var contentPath = new DataPath(regex.Match(resourceName).Groups[1].Value.Split('.'));
                
                var fullBasePath = includeResourceName
                        ? DataPath.Combine(basePath, contentPath)
                        : basePath ?? DataPath.Empty;

                using var jsonDocument = JsonDocument.Parse(content);
                AddJsonElementValuesToDataHub(dataHub, fullBasePath, jsonDocument.RootElement);
            }
        }

        private void AddJsonElementValuesToDataHub(DataHub dataHub, DataPath basePath, JsonElement jsonElement)
        {
            if(jsonElement.ValueKind == JsonValueKind.Object)
            {
                foreach(var jsonProperty in jsonElement.EnumerateObject())
                {
                    var path = DataPath.Combine(basePath, new DataPath(jsonProperty.Name));
                    AddJsonElementValuesToDataHub(dataHub, path, jsonProperty.Value);
                }
            }
            else
            {
                dataHub.Add(basePath, GetJsonElementValue(jsonElement));
            }            
        }

        private object GetJsonElementValue(JsonElement jsonElement)
        {
            return jsonElement.ValueKind switch
            {
                JsonValueKind.False => false,
                JsonValueKind.True => true,
                JsonValueKind.Number => jsonElement.GetDouble(),
                JsonValueKind.String => jsonElement.GetString()!,
                _ => throw new NotImplementedException("Unsupported json token")
            };
        }
    }
