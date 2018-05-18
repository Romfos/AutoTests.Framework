using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Steps;
using AutoTests.Framework.Example.Comparator;
using AutoTests.Framework.Example.Web;
using AutoTests.Framework.Models;
using AutoTests.Framework.Models.Comparator;
using AutoTests.Framework.PreProcessor;
using AutoTests.Framework.Web;
using BoDi;

namespace AutoTests.Framework.Example
{
    public class Application : Dependencies
    {
        public Application(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public StepsDependencies Steps => ObjectContainer.Resolve<StepsDependencies>();

        public WebDependencies Web => ObjectContainer.Resolve<WebDependencies>();

        public ModelsDependencies Models => ObjectContainer.Resolve<ModelsDependencies>();

        public PreProcessorDependencies PreProcessor => ObjectContainer.Resolve<PreProcessorDependencies>();

        protected override void OnDependenciesRegistered()
        {
            ObjectContainer.RegisterTypeAs<ChromeDriverProvider, IWebDriverProvider>();
            ObjectContainer.RegisterTypeAs<ExampleModelComparator, ModelComparator>();
        }
    }
}