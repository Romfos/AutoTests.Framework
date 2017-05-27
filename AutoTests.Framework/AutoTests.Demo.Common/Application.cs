﻿using System.Reflection;
using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Steps;
using AutoTests.Framework.Core.Stores;
using AutoTests.Framework.Core.Transformations;
using AutoTests.Framework.Core.Utils;
using AutoTests.Framework.Models;
using AutoTests.Framework.PreProcessor;
using AutoTests.Framework.Resources;
using AutoTests.Framework.Web;
using BoDi;

namespace AutoTests.Demo.Common
{
    public class Application : Dependencies
    {
        public Application(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        internal CoreDependencies Core => ObjectContainer.Resolve<CoreDependencies>();

        public UtilsDependencies Utils => ObjectContainer.Resolve<UtilsDependencies>();

        public StoresDependencies Stores => ObjectContainer.Resolve<StoresDependencies>();

        public ModelsDependencies Models => ObjectContainer.Resolve<ModelsDependencies>();

        public WebDependencies Web => ObjectContainer.Resolve<WebDependencies>();

        public PreProcessorDependencies PreProcessor => ObjectContainer.Resolve<PreProcessorDependencies>();

        public StepsDependencies Steps => ObjectContainer.Resolve<StepsDependencies>();

        public StepArgumentTransformationsDependencies StepArgumentTransformations
            => ObjectContainer.Resolve<StepArgumentTransformationsDependencies>();

        public ResourcesDependencies Resources => ObjectContainer.Resolve<ResourcesDependencies>();

        protected override void CustomRegister()
        {
            Core.AddAssembly(Assembly.GetExecutingAssembly());

            Steps.Register();
            Utils.Register();
            Models.Register();
            PreProcessor.Register();
            Stores.Register();
            StepArgumentTransformations.Register();
            Web.Register();
            Resources.Register();
        }

        protected override void CustomConfigure()
        {
            Steps.Configure();
            Utils.Configure();
            Models.Configure();
            PreProcessor.Configure();
            Stores.Configure();
            StepArgumentTransformations.Configure();
            Web.Configure();
            Resources.Configure();
        }
    }
}