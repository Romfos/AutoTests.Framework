using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Specflow;
using BoDi;
using System.Reflection;

namespace AutoTests.Framework.Tests.UnitTests;

    public abstract class UnitTestsBase
    {
        protected IContainer CreateEmptyContainer()
        {
            return new SpecflowContainer(new ObjectContainer(), Assembly.GetExecutingAssembly());
        }
    }
