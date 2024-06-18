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
        public static T? GetMax<T>(this IEnumerable collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null) throw new ArgumentNullException(typeof(T).ToString());
            if (!collection.GetEnumerator().MoveNext())
            {
                throw new ArgumentException("Collection is empty", nameof(collection));
            }

            var maxVal = float.MinValue;
            var result = default(T);

            foreach (var item in collection)
            {
                float floatItem;
                try
                {
                    floatItem = convertToNumber((T)item);
                }catch (FormatException)
                {
                    return null;
                }

                if (floatItem > maxVal)
                {
                    maxVal = floatItem;
                    result = (T)item;
                }
            }
            return result;
        }
    }
}
