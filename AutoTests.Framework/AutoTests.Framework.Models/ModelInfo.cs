using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoTests.Framework.Core.Exceptions;
using AutoTests.Framework.Models.PropertyAttributes;

namespace AutoTests.Framework.Models
{
    public class ModelInfo
    {
        private readonly Model model;
        private readonly PropertyLink[] propertyLinks;

        internal ModelInfo(Model model)
        {
            this.model = model;
            CheckConstraints();
            propertyLinks = CreatePropertyLinks();
        }

        public PropertyLink[] GetPropertyLinks()
        {
            return propertyLinks;
        }

        private PropertyLink[] CreatePropertyLinks()
        {
            return Enumerable.Concat(CreateModelPropertyLinks(), CreateSubModelsPropertyLinks()).ToArray();
        }

        private IEnumerable<PropertyLink> CreateModelPropertyLinks()
        {
            return GetModelProperties().Select(property => new PropertyLink(model, property));
        }

        private IEnumerable<PropertyLink> CreateSubModelsPropertyLinks()
        {
            return CreateSubModels().SelectMany(x => x.GetModelInfo().GetPropertyLinks());
        }

        private IEnumerable<Model> CreateSubModels()
        {
            foreach (var property in GetSubModelProperties())
            {
                var subModel = (Model)Activator.CreateInstance(property.PropertyType);
                property.SetValue(model, subModel);
                yield return subModel;
            }
        }

        private IEnumerable<PropertyInfo> GetModelProperties()
        {
            return GetProperties().Where(x => !x.PropertyType.IsSubclassOf(typeof(Model)));
        }

        private IEnumerable<PropertyInfo> GetSubModelProperties()
        {
            return GetProperties().Where(x => x.PropertyType.IsSubclassOf(typeof(Model)));
        }
        
        private IEnumerable<PropertyInfo> GetProperties()
        {
            var bindingFlags = BindingFlags.Instance
                               | BindingFlags.GetProperty
                               | BindingFlags.SetProperty
                               | BindingFlags.Public
                               | BindingFlags.NonPublic;

            return model.GetType().GetProperties(bindingFlags).Where(x => !x.GetIndexParameters().Any());
        }

        private void CheckConstraints()
        {
            if (model.GetType().GetConstructors().All(x => x.GetParameters().Length != 0))
            {
                throw new ClassConstraintException(model.GetType(), 
                    "Model '{0}' should contain constructor without parameters");
            }

            foreach (var property in GetSubModelProperties())
            {
                if (!property.CanWrite || !property.SetMethod.IsPrivate)
                {
                    throw new PropertyConstraintException(property, 
                        "Property '{0}' should contain private setter");
                }

                if (property.GetCustomAttributes<PropertyAttribute>().Any())
                {
                    throw new PropertyConstraintException(property,
                        "Property '{0}' cannot contain property attributes");
                }
            }
        }
    }
}