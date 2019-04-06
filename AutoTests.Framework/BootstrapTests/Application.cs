using AutoTests.Framework.Core;
using AutoTests.Framework.PageObjects;
using BoDi;
using BootstrapTests.Web;

namespace BootstrapTests
{
    public class Application : ServiceProvider
    {
        public Application(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public T GetContext<T>()
            where T : Context
        {
            return ObjectContainer.Resolve<T>();
        }

        public PageObjectsServiceProvider PageObjects => ObjectContainer.Resolve<PageObjectsServiceProvider>();
    }
}
