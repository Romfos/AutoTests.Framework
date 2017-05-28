using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoTests.Framework.Core.Exceptions;
using Newtonsoft.Json.Linq;

namespace AutoTests.Framework.Web
{
    public abstract class Page
    {
        private readonly WebDependencies dependencies;

        protected Page(WebDependencies dependencies)
        {
            this.dependencies = dependencies;
            CheckConstraints();
            SetupControls();
        }

        private void SetupControls()
        {
            var locators = dependencies.Utils.Resources.GetJsonResource(this, "Locators.json");

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

        public void CheckConstraints()
        {
            if (!dependencies.Utils.Resources.CheckResource(this, "Locators.json"))
            {
                throw new ClassConstraintException(GetType(),
                    "Locators.json not found. Page '{0}'");
            }

            foreach (var property in GetPageControlProperties())
            {
                if (!property.CanWrite || !property.SetMethod.IsPrivate)
                {
                    throw new PropertyConstraintException(property,
                        "Property '{0}' should contain private setter");
                }
            }
        }
    }
}