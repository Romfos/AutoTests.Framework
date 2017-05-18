using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace AutoTests.Framework.Web
{
    public abstract class Page
    {
        protected Page(WebDependencies dependencies)
        {
            SetupControls(dependencies);
        }

        private void SetupControls(WebDependencies dependencies)
        {
            var locators = dependencies.Resources.GetJsonResource(this, "Locators.json");

            foreach (var property in GetPageControlProperties())
            {
                var arguments = locators[property.Name];
                var control = dependencies.CreateControl(property.PropertyType);
                SetControlArguments(control, arguments);
                property.SetValue(this, control);
            }
        }

        private void SetControlArguments(Control control, JToken arguments)
        {
            var properties = GetControlArgumentProperties(control);
            if (properties.Length == 1)
            {
                var property = properties[0];
                property.SetValue(control, arguments.ToObject(property.PropertyType));
            }
            if (properties.Length > 1)
            {
                foreach (var property in properties)
                {
                    property.SetValue(control, arguments[property.Name].ToObject(property.PropertyType));
                }
            }
        }

        private PropertyInfo[] GetControlArgumentProperties(Control control)
        {
            var bindingFlags = BindingFlags.Instance
                               | BindingFlags.GetProperty
                               | BindingFlags.SetProperty
                               | BindingFlags.Public
                               | BindingFlags.NonPublic;

            return control.GetType()
                .GetProperties(bindingFlags)
                .Where(x => !x.GetIndexParameters().Any())
                .Where(x => x.CanRead && x.CanWrite && x.SetMethod.IsPrivate)
                .ToArray();
        }

        private IEnumerable<PropertyInfo> GetPageControlProperties()
        {
            var bindingFlags = BindingFlags.Instance
                               | BindingFlags.GetProperty
                               | BindingFlags.SetProperty
                               | BindingFlags.Public
                               | BindingFlags.NonPublic;

            return GetType()
                .GetProperties(bindingFlags)
                .Where(x => x.PropertyType.IsSubclassOf(typeof(Control)))
                .Where(x => !x.GetIndexParameters().Any());
        }
    }
}