using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public static class EnumerableExtesions
    {
        public static T? GetMax<T>(this IEnumerable collection, Func<T, IComparable> convertToNumber) where T : class
        {
            if (collection == null) throw new ArgumentNullException(typeof(T).ToString());
            
            var maxVal = default(T);
            foreach (var item in collection)
            {
                if (((IComparable)item).CompareTo(maxVal) >= 0)
                {
                    var current = convertToNumber((T)item);
                    maxVal = (T)current;
                }
            }
            return maxVal;
        }
    }
}
