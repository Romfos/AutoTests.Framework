using AutoTests.Framework.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoTests.Framework.Models
{
    public class ModelInfo
    {
        private readonly List<Model> nestedModels;
        private readonly List<PropertyLink> propertyLinks;

        public ModelInfo(Model model)
        {
            ValidateModel(model);
            CreateNestedModels(model);
            nestedModels = GetNestedModels(model);
            propertyLinks = GetPropertyLinks(model);
        }

        public PropertyLink GetPropertyLink(PropertyInfo propertyInfo)
        {
            return propertyLinks.Single(x => x.PropertyInfo == propertyInfo);
        }

        public IEnumerable<PropertyLink> GetPropertyLinks()
        {
            return nestedModels
                .SelectMany(x => x.GetModelInfo().GetPropertyLinks())
                .Concat(propertyLinks);
        }

        private void ValidateModel(Model model)
        {
            var type = model.GetType();
            ValidateModelConstructor(type);
            foreach (var property in GetNestedModelProperties(model))
            {
                ValidateNestedModelProperty(type, property);
            }
        }

        private void ValidateModelConstructor(Type modelType)
        {
            if (!modelType.GetConstructors().Any(x => !x.GetParameters().Any()))
            {
                throw new AutoTestFrameworkException(
                    $"Model '{modelType.FullName}' must have constructor without argruments");
            }
        }

        private void ValidateNestedModelProperty(Type modelType, PropertyInfo property)
        {
            if (!(property.CanRead 
                && property.CanWrite 
                && !property.GetIndexParameters().Any() 
                && property.SetMethod!.IsPrivate))
            {
                throw new AutoTestFrameworkException(
                    $"Property '{modelType.GetType().FullName}.{property.Name}' must have getter and private setter");
            }
        }

        private void CreateNestedModels(Model model)
        {
            foreach (var property in GetNestedModelProperties(model))
            {
                ValidateModelConstructor(property.PropertyType);
                var nestedModel = Activator.CreateInstance(property.PropertyType);
                property.SetValue(model, nestedModel);
            }
        }

        private List<Model> GetNestedModels(Model model)
        {
            return GetNestedModelProperties(model).Select(x => (Model)x.GetValue(model)!).ToList();
        }

        private List<PropertyLink> GetPropertyLinks(Model model)
        {
            return GetValuableProperties(model).Select(x => new PropertyLink(model, x)).ToList();
        }

        private IEnumerable<PropertyInfo> GetValuableProperties(Model model)
        {
            return GetProperties(model).Where(x => !x.PropertyType.IsSubclassOf(typeof(Model)));
        }

        private IEnumerable<PropertyInfo> GetNestedModelProperties(Model model)
        {
            return GetProperties(model).Where(x => x.PropertyType.IsSubclassOf(typeof(Model)));
        }

        private IEnumerable<PropertyInfo> GetProperties(Model model)
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            return model.GetType().GetProperties(bindingFlags);
        }
    }
}
