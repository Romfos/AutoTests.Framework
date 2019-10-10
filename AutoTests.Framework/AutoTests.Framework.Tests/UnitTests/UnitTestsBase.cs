using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Specflow;
using BoDi;
using System.Reflection;

namespace AutoTests.Framework.Tests.UnitTests
{
    public abstract class UnitTestsBase
    {
        protected SpecflowContainer CreateEmptyContainer()
        {
            var container = new ObjectContainer();
            var specflowContainer = new SpecflowContainer(container, Assembly.GetExecutingAssembly());
            container.RegisterInstanceAs<IContainer>(specflowContainer);
            return specflowContainer;
        }
    }
}
