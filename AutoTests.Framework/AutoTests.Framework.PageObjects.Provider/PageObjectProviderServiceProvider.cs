using System.Linq;
using AutoTests.Framework.Core;
using AutoTests.Framework.PageObjects.Provider.Attributes;
using BoDi;

namespace AutoTests.Framework.PageObjects.Provider
{
    public class PageObjectProviderServiceProvider : ServiceProvider
    {
        public PageObjectProviderServiceProvider(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public PageObjectProvider PageObjectProvider => ObjectContainer.Resolve<PageObjectProvider>();

        internal AssemblyPool AssemblyPool => ObjectContainer.Resolve<AssemblyPool>();

        internal Page GetPage(string name)
        {
            return AssemblyPool.Assemblies.SelectMany(x => x.GetTypes())
                .Where(x => x.IsSubclassOf(typeof(Page)))
                .Where(x => x.GetCustomAttributes(true).OfType<PageObjectNameAttribute>().Any(y => y.Name == name))
                .Select(x => (Page) ObjectContainer.Resolve(x))
                .Single();
        }
    }
}