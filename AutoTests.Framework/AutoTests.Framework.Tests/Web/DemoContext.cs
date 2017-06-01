using System.Collections.Generic;
using AutoTests.Framework.Web;

namespace AutoTests.Framework.Tests.Web
{
    public class DemoContext : Context
    {
        public List<string> Log { get; } = new List<string>();

        public void Click(string locator)
        {
            Log.Add($"Click({locator})");
        }

        public void SetValue(string locator, string value)
        {
            Log.Add($"SetValue({locator}, {value})");
        }
    }
}