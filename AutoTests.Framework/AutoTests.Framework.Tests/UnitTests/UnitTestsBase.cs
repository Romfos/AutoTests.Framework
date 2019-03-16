using AutoTests.Framework.Core;
using AutoTests.Framework.PreProcessor.Roslyn;
using BoDi;

namespace AutoTests.Framework.Tests.UnitTests
{
    public abstract class UnitTestsBase
    {
        protected readonly Application application;

        protected UnitTestsBase()
        {
            application = new ObjectContainer().Resolve<AutoTestsFrameworkBuilder>()
                .RegisterAssemblyForType<Application>()
                .UseRoslynPreProcessor()
                .Build<Application>();
        }
    }
}