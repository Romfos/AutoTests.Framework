using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AutoTests.Framework.Models.Attributes;

namespace AutoTests.Framework.Models
{
    public class PropertyLink
    {
        public Model Model { get; }
        public PropertyInfo PropertyInfo { get; }
        public List<ModelPropertyAttribute> Attributes { get; }

        internal PropertyLink(Model model, PropertyInfo propertyInfo)
        {
            Model = model;
            PropertyInfo = propertyInfo;
            Attributes = GetModelProperties();
        }

        public static PropertyLink Get<T>(Expression<Func<T>> expression)
        {
            var body = expression.Body as MemberExpression;
            var getModel = Expression.Lambda<Func<Model>>(body.Expression).Compile();
            var propertyInfo = body.Member as PropertyInfo;
            return getModel().GetModelInfo().GetPropertyLinks().Single(x => x.PropertyInfo == propertyInfo);
        }

        public object Value
        {
            get => PropertyInfo.GetValue(Model);
            set => PropertyInfo.SetValue(Model, value);
        }

        public string Name => CheckAttribute<NameAttribute>()
            ? GetSingleAttribute<NameAttribute>().Value
            : PropertyInfo.Name;

        public bool Enabled
        {
            get => !CheckAttribute<DisabledAttribute>();
            set
            {
                if (value && CheckAttribute<DisabledAttribute>())
                {
                    RemoveAttributes<DisabledAttribute>();
                }
                if (!value && !CheckAttribute<DisabledAttribute>())
                {
                    Attributes.Add(new DisabledAttribute());
                }
            }
        }

        public bool CheckAttribute<T>(Func<T, bool> condition = null)
            where T: ModelPropertyAttribute
        {
            return Attributes.OfType<T>().Any(x => condition == null || condition(x));
        }

        public T GetSingleAttribute<T>(Func<T, bool> condition = null)
            where T : ModelPropertyAttribute
        {
            return Attributes.OfType<T>().Single(x => condition == null || condition(x));
        }

        public void RemoveAttributes<T>(Func<T, bool> condition = null)
            where T : ModelPropertyAttribute
        {
            Attributes.RemoveAll(x => x is T && (condition == null || condition((T) x)));
        }

        private List<ModelPropertyAttribute> GetModelProperties()
        {
            return PropertyInfo.GetCustomAttributes<ModelPropertyAttribute>().ToList();
        }
    }
}