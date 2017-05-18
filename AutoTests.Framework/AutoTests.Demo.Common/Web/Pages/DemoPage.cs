﻿using AutoTests.Framework.Web;

namespace AutoTests.Demo.Common.Web.Pages
{
    public abstract class DemoPage : Page
    {
        protected Application Application { get; }

        protected DemoPage(Application application) : base(application.Web)
        {
            Application = application;
        }
    }
}