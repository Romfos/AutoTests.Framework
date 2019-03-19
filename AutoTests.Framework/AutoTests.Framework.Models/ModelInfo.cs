using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoTests.Framework.Models
{
    public class ModelInfo
    {
        private readonly Model model;
        private readonly PropertyLink[] propertyLinks;

        internal ModelInfo(Model model)
        {
            this.model = model;
            ValidateModelProperties();
            CreateNestedModels();
            propertyLinks = CreatePropertyLinks();
        }

        public IEnumerable<PropertyLink> GetPropertyLinks()
        {
            return propertyLinks;
        }

        private PropertyLink[] CreatePropertyLinks()
        {
            return GetValueProperties().Select(x => new PropertyLink(model, x))
                .Concat(GetNestedModels().SelectMany(x => x.GetModelInfo().GetPropertyLinks()))
                .ToArray();
        }

        private void CreateNestedModels()
        {
            foreach (var nestedModelProperty in GetNestedModelProperties())
            {
                var nestedModel = Activator.CreateInstance(nestedModelProperty.PropertyType);
                nestedModelProperty.SetValue(model, nestedModel);
            }
        }

        private void ValidateModelProperties()
        {
            foreach (var property in GetProperties())
            {
                ValidateModelProperty(property);
            }
        }

        private void ValidateModelProperty(PropertyInfo property)
        {
            if (!property.CanRead)
            {
                throw new Exception(string.Format(
                    "Property '{0}' in type '{1}' must contains getter",
                    property.Name, property.DeclaringType.FullName));
            }
            if (!property.CanWrite)
            {
                throw new Exception(string.Format(
                    "Property '{0}' in type '{1}' must contains setter",
                    property.Name, property.DeclaringType.FullName));
            }
            if (property.GetIndexParameters().Any())
            {
                throw new Exception(string.Format(
                    "Property '{0}' in type '{1}' shouldn't contain index parameters",
                    property.Name, property.DeclaringType.FullName));
            }
            if (property.PropertyType.IsSubclassOf(typeof(Model)))
            {
                if (property.PropertyType.IsAbstract)
                {
                    throw new Exception(string.Format(
                        "Property type for '{0}' in type '{1}' shouldn't be abstract",
                        property.Name, property.DeclaringType.FullName));
                }
                if (!property.SetMethod.IsPrivate)
                {
                    throw new Exception(string.Format(
                        "Modificator for property '{0}' setter in type '{1}' should be private",
                        property.Name, property.DeclaringType.FullName));
                }
            }
        }

        private IEnumerable<Model> GetNestedModels()
        {
            return GetNestedModelProperties().Select(x => x.GetValue(model)).Cast<Model>();
        }

        private IEnumerable<PropertyInfo> GetValueProperties()
        {
            return GetProperties().Where(x => !x.PropertyType.IsSubclassOf(typeof(Model)));
        }

        private IEnumerable<PropertyInfo> GetNestedModelProperties()
        {
            return GetProperties().Where(x => x.PropertyType.IsSubclassOf(typeof(Model)));
        }

        private IEnumerable<PropertyInfo> GetProperties()
        {
            return model.GetType().GetProperties(GetBindingFlags());
        }

        private BindingFlags GetBindingFlags()
        {
            return BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
        }
    }
}