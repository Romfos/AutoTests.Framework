using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AutoTests.Framework.Models.PropertyAttributes;

namespace AutoTests.Framework.Models
{
    public class PropertyLink
    {
        public Model Model { get; }
        public PropertyInfo PropertyInfo { get; }
        public List<PropertyAttribute> Attributes { get; }

        public PropertyLink(Model model, PropertyInfo propertyInfo)
        {
            Model = model;
            PropertyInfo = propertyInfo;
            Attributes = GetPropertyAttributes();
        }

        public static PropertyLink Get<T>(Expression<Func<T>> expression)
        {
            var body = expression.Body as MemberExpression;
            var getModel = Expression.Lambda<Func<Model>>(body.Expression).Compile();
            var propertyInfo = body.Member as PropertyInfo;
            return getModel().GetModelInfo().GetPropertyLinks().Single(x => x.PropertyInfo == propertyInfo);
        }

        public string Name => CheckAttribute<NameAttribute>()
            ? GetAttribute<NameAttribute>().Value
            : PropertyInfo.Name;

        public bool Enabled
        {
            get => !CheckAttribute<DisabledAttribute>();
            set
            {
                if (CheckAttribute<DisabledAttribute>() && value)
                {
                    RemoveAttributse<DisabledAttribute>();
                }
                if (!CheckAttribute<DisabledAttribute>() && !value)
                {
                    Attributes.Add(new DisabledAttribute());
                }
            }
        }

        private List<PropertyAttribute> GetPropertyAttributes()
        {
            return PropertyInfo.GetCustomAttributes<PropertyAttribute>().ToList();
        }

        public void RemoveAttributse<T>()
            where T : PropertyAttribute
        {
            Attributes.RemoveAll(x => x is T);
        }

        public T GetAttribute<T>()
            where T : PropertyAttribute
        {
            return Attributes.OfType<T>().Single();
        }

        public bool CheckAttribute<T>()
            where T : PropertyAttribute
        {
            return Attributes.OfType<T>().Any();
        }
    }
}