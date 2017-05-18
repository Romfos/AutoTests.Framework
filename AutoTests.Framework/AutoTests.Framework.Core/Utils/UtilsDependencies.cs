﻿using BoDi;

namespace AutoTests.Framework.Core.Utils
{
    public class UtilsDependencies : Dependencies
    {
        public UtilsDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public ResourceUtils Utils => ObjectContainer.Resolve<ResourceUtils>();

        public override void Setup()
        {
            
        }
    }
}