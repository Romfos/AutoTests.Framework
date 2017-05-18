using AutoTests.Framework.Models;

namespace AutoTests.Framework.Web.Binding
{
    public interface IBind
    {
        PropertyLink PropertyLink { get; }

        void Click();
        void GetValue();
        void SetValue();
        bool IsEnabled();
        bool IsSelected();
        bool IsDisplayed();

        bool CanClick { get; }
        bool CanGetValue { get; }
        bool CanSetValue { get; }
        bool CanBeEnabled { get; }
        bool CanBeSelected { get; }
        bool CanBeDisplayed { get; }
    }
}