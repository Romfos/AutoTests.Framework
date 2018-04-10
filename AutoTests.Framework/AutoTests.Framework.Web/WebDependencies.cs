using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Utils;
using AutoTests.Framework.Web.Configurators;
using BoDi;

namespace AutoTests.Framework.Web
{
    public class WebDependencies : Dependencies
    {
        public WebDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        internal UtilsDependencies Utils => ObjectContainer.Resolve<UtilsDependencies>();

        public IWebDriverFactory WebDriverFactory => ObjectContainer.Resolve<IWebDriverFactory>();

        internal ConfiguratorsDependencies Configurators => ObjectContainer.Resolve<ConfiguratorsDependencies>();

        public T GetPage<T>()
            where T : Page
        {
            return ObjectContainer.Resolve<T>();
        }

        public T GetContext<T>()
            where T : Context
        {
            return ObjectContainer.Resolve<T>();
        }

        public T GetScriptLibrary<T>()
            where T : ScriptLibrary
        {
            return ObjectContainer.Resolve<T>();
        }
    }
}