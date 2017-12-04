﻿using AutoTests.Framework.Web.Common.Handlers;

namespace AutoTests.Framework.Web.Common.Elements
{
    public class Dropdown : CommonElement
    {
        private string Locator { get; set; }

        public Dropdown(WebDependencies dependencies) : base(dependencies)
        {
        }

        [Displayed]
        public bool IsDisplayed()
        {
            return Context.IsDisplayed(Locator);
        }

        [Enabled]
        public bool IsEnabled()
        {
            return Context.IsEnabled(Locator);
        }

        [Selected]
        public bool IsSelected()
        {
            return Context.IsSelected(Locator);
        }

        [GetValue]
        public string GetValue()
        {
            return CommonScriptLibrary.GetValue(Locator);
        }

        [SetValue]
        public void SetValue(string value)
        {
            CommonScriptLibrary.SetValue(Locator, value);
        }
    }
}