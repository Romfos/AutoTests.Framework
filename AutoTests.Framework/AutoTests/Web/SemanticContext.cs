﻿using System;
using AutoTests.Framework.Web;
using OpenQA.Selenium;

namespace AutoTests.Web
{
    public class SemanticContext : Context, IDisposable
    {
        private readonly IWebDriver driver;

        public SemanticContext(Application application)
        {
            driver = application.Web.WebDriverFactory.CreateWebDriver();
        }

        public void Navigate(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void Click(string locator)
        {
            driver.FindElement(By.XPath(locator)).Click();
        }

        public void SetValue(string locator, string value)
        {
            driver.FindElement(By.XPath(locator)).SendKeys(value);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}