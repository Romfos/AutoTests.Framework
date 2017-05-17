using System.Reflection;

namespace AutoTests.Framework.Core.Exceptions
{
    public class PropertyConstraintException : ConstraintException
    {
        public PropertyConstraintException(PropertyInfo propertyInfo, string format) 
            : base(string.Format(format, $"{propertyInfo.DeclaringType.Name}.{propertyInfo.Name}"))
        {
        }
    }
}