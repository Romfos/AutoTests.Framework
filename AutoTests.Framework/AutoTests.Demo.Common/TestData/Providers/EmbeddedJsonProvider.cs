﻿using System.Collections.Generic;
using System.Reflection;
using AutoTests.Framework.TestData.Entities;
using AutoTests.Framework.TestData.TestDataProviders;

namespace AutoTests.Demo.Common.TestData.Providers
{
    public class EmbeddedJsonProvider : EmbeddedJsonProviderBase
    {
        public EmbeddedJsonProvider(Application application)
            : base(application.TestData)
        {
        }

        protected override IEnumerable<EmbeddedResourceLocation> GetResoruceLocations()
        {
            yield return new EmbeddedResourceLocation(
                Assembly.GetExecutingAssembly(),
                "AutoTests.Demo.Common.TestData.Resources.(.*).json");
        }
    }
}