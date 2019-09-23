using AutoTests.Framework.Core.Specflow;
using BoDi;
using System.Reflection;

namespace AutoTests.Framework.Tests.UnitTests
{
    public abstract class UnitTestsBase
    {
        protected SpecflowContainer CreateEmptyContainer()
        {
            return new SpecflowContainer(new ObjectContainer(), Assembly.GetExecutingAssembly());
        }
    }
}
