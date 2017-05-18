using System;
using AutoTests.Framework.Models.PropertyAttributes;

namespace AutoTests.Framework.Models.Transformations
{
    public class ModelTransformations
    {
        private readonly ModelsDependencies dependencies;

        public ModelTransformations(ModelsDependencies dependencies)
        {
            this.dependencies = dependencies;
        }

        public T Transform<T>(Prototype[] prototypes)
            where T : Model, new()
        {
            var model = new T();
            SetupPropertyLins(model.GetModelInfo().GetPropertyLinks(), prototypes);
            return model;
        }

        private void SetupPropertyLins(PropertyLink[] propertyLinks, Prototype[] prototypes)
        {
            foreach (var propertyLink in propertyLinks)
            {
                var prototype = FindPrototype(propertyLink, prototypes);
                if (prototype != null)
                {
                    SetupPropertyLink(propertyLink, prototype);
                }
                else
                {
                    propertyLink.Enabled = false;
                }
            }
        }

        private Prototype FindPrototype(PropertyLink propertyLink, Prototype[] prototypes)
        {
            foreach (var prototype in prototypes)
            {
                if (propertyLink.Name == prototype.Name)
                {
                    return prototype;
                }
            }
            return null;
        }
        
        private void SetupPropertyLink(PropertyLink propertyLink, Prototype prototype)
        {
            TransformValue(propertyLink, prototype.Value);
            TransformAttributes(propertyLink, prototype.Attributes);
        }

        private void TransformValue(PropertyLink propertyLink, string source)
        {
            propertyLink.Value = Convert.ChangeType(
                dependencies.Compiler.Compile(source),
                propertyLink.PropertyInfo.PropertyType);
        }

        private void TransformAttributes(PropertyLink propertyLink, string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return;
            }

            propertyLink.Attributes.Add((PropertyAttribute)dependencies.Compiler.Compile(source));
        }
    }
}