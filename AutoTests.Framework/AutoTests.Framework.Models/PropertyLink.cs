using AutoTests.Framework.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoTests.Framework.Models
{
    public class PropertyLink
    {
        public Model Model { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
        public List<ModelPropertyAttribute> Attributes { get; }

        public PropertyLink(Model model, PropertyInfo propertyInfo)
        {
            Model = model;
            PropertyInfo = propertyInfo;
            Attributes = GetModelPropertyAttributes(propertyInfo);
        }

        public static PropertyLink From<T>(Expression<Func<T>> expression)
        {
            var memberExpression = (MemberExpression)expression.Body;
            var model = Expression.Lambda<Func<Model>>(memberExpression.Expression).Compile()();
            var propertyInfo = (PropertyInfo)memberExpression.Member;
            return model.GetModelInfo().GetPropertyLink(propertyInfo);
        }

        public object? Value
        {
            get => PropertyInfo.GetValue(Model);
            set => PropertyInfo.SetValue(Model, value);
        }

        public string Name => Attributes.OfType<NameAttribute>().Select(x => x.Name).SingleOrDefault() ?? PropertyInfo.Name;

        public bool Enabled
        {
            get => GetSingleAttribute<DisabledAttribute>() == null;
            set
            {
                if (GetSingleAttribute<DisabledAttribute>() != null && value)
                {
                    Attributes.RemoveAll(x => x is DisabledAttribute);
                }
                if (GetSingleAttribute<DisabledAttribute>() == null && !value)
                {
                    Attributes.Add(new DisabledAttribute());
                }
            }
        }

        public T? GetSingleAttribute<T>()
            where T : ModelPropertyAttribute
        {
            return Attributes.OfType<T>().SingleOrDefault();
        }

        private List<ModelPropertyAttribute> GetModelPropertyAttributes(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes().OfType<ModelPropertyAttribute>().ToList();
        }
    }
}
