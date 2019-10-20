using System;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoTests.Framework.Models
{
    public class PropertyLink
    {
        public Model Model { get; set; }
        public PropertyInfo PropertyInfo { get; set; }

        public PropertyLink(Model model, PropertyInfo propertyInfo)
        {
            Model = model;
            PropertyInfo = propertyInfo;
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

        public string Name => PropertyInfo.Name;
    }
}
