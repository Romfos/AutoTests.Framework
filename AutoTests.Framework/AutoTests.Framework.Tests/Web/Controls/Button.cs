﻿using AutoTests.Framework.Web.Binding.Contracts;

namespace AutoTests.Framework.Tests.Web.Controls
{
    public class Button : DemoControl, IClick
    {
        public string Locator { get; private set; }

        public Button(DemoContext context) : base(context)
        {
        }

        public void Click()
        {
            Context.Click(Locator);
        }
    }
}