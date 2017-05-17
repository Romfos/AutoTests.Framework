using System;

namespace AutoTests.Framework.Models.Transformations
{
    public class ModelTransformations
    {
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
        }

        private void TransformValue(PropertyLink propertyLink, string source)
        {
            propertyLink.Value = Convert.ChangeType(source, propertyLink.PropertyInfo.PropertyType);
        }
    }
}