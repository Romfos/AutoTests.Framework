using System.Collections.Generic;
using System.Linq;

namespace AutoTests.Framework.Core.Extensions
{
    public static class IEnumerableExtensions
    {
        public static T FirstNotNull<T>(this IEnumerable<T> enumerable)
            where T : class
        {
            return enumerable.FirstOrDefault(x => x != null);
        }
    }
}