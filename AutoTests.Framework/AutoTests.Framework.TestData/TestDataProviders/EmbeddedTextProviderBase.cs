﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AutoTests.Framework.TestData.Entities;

namespace AutoTests.Framework.TestData.TestDataProviders
{
    public abstract class EmbeddedTextProviderBase : TestDataProvider
    {
        private readonly TestDataDependencies dependencies;

        protected Dictionary<string, string> Resources { get; }

        protected EmbeddedTextProviderBase(TestDataDependencies dependencies)
        {
            this.dependencies = dependencies;

            Resources = LoadResources().ToDictionary(x => x.Key, x => x.Value);
        }

        public override object GetResoruce(string name)
        {
            return Resources.ContainsKey(name) ? Resources[name] : null;
        }

        protected abstract IEnumerable<EmbeddedResourceLocation> GetResoruceLocations();

        private IEnumerable<KeyValuePair<string, string>> LoadResources()
        {
            return GetResoruceLocations().SelectMany(LoadResources);
        }

        private IEnumerable<KeyValuePair<string, string>> LoadResources(EmbeddedResourceLocation location)
        {
            var regex = new Regex(location.Pattern);

            return location.Assembly.GetManifestResourceNames()
                .Where(x => regex.IsMatch(x))
                .Select(x => new KeyValuePair<string, string>(regex.Match(x).Groups[1].Value,
                    dependencies.Utils.Resources.GetTextResource(location.Assembly, x)));
        }
    }
}