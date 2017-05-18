using AutoTests.Framework.Models;
using AutoTests.Framework.Web.Binding.Contracts;

namespace AutoTests.Framework.Web.Binding
{
    public class Bind<T> : IBind
    {
        private readonly PageObject pageObject;

        public Bind(PropertyLink propertyLink, PageObject pageObject)
        {
            PropertyLink = propertyLink;
            this.pageObject = pageObject;
        }

        public PropertyLink PropertyLink { get; }

        public bool CanClick => Check<IClick>();

        public bool CanGetValue => Check<IGetValue<T>>();

        public bool CanSetValue => Check<ISetValue<T>>();

        public bool CanBeEnabled => Check<IEnabled>();

        public bool CanBeSelected => Check<ISelected>();

        public bool CanBeDisplayed => Check<IDisplayed>();

        public void Click()
        {
            Get<IClick>().Click();
        }

        public void GetValue()
        {
            PropertyLink.Value = Get<IGetValue<T>>().GetValue();
        }

        public void SetValue()
        {
            Get<ISetValue<T>>().SetValue((T) PropertyLink.Value);
        }

        public bool IsEnabled()
        {
            return Get<IEnabled>().Enabled;
        }

        public bool IsSelected()
        {
            return Get<ISelected>().Selected;
        }

        public bool IsDisplayed()
        {
            return Get<IDisplayed>().Displayed;
        }

        private T Get<T>()
            where T : class, IContract
        {
            return pageObject as T;
        }

        private bool Check<T>()
            where T : class, IContract
        {
            return pageObject is T;
        }
    }
}