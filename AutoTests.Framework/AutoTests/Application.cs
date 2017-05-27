﻿using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Steps;
using AutoTests.Framework.Core.Stores;
using AutoTests.Framework.Core.Transformations;
using AutoTests.Framework.Models;
using AutoTests.Framework.PreProcessor;
using AutoTests.Framework.PreProcessor.Infrastructure;
using AutoTests.Framework.TestData;
using AutoTests.Framework.Web;
using AutoTests.PreProcessor;
using AutoTests.Web;
using BoDi;

namespace AutoTests
{
    public class Application : Dependencies
    {
        public Application(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public StepsDependencies Steps => ObjectContainer.Resolve<StepsDependencies>();

        public StoresDependencies Stores => ObjectContainer.Resolve<StoresDependencies>();

        public PreProcessorDependencies PreProcessor => ObjectContainer.Resolve<PreProcessorDependencies>();

        public WebDependencies Web => ObjectContainer.Resolve<WebDependencies>();

        public ModelsDependencies Models => ObjectContainer.Resolve<ModelsDependencies>();

        public ResourcesDependencies Resources => ObjectContainer.Resolve<ResourcesDependencies>();

        private StepArgumentTransformationsDependencies StepArgumentTransformations
            => ObjectContainer.Resolve<StepArgumentTransformationsDependencies>();

        protected override void RegisterCustomTypes()
        {
            ObjectContainer.RegisterTypeAs<IWebDriverFactory>(typeof(ChromeDriverFactory));
            ObjectContainer.RegisterTypeAs<Options>(typeof(ExampleOptions));

            Steps.Register();
            Stores.Register();
            PreProcessor.Register();
            Models.Register();
            StepArgumentTransformations.Register();
            Web.Register();
            Resources.Register();
        }

        protected override void ConfigureDependencies()
        {
            Steps.Configure();
            Stores.Configure();
            PreProcessor.Configure();
            Models.Configure();
            StepArgumentTransformations.Configure();
            Web.Configure();
            Resources.Configure();
        }
    }
}