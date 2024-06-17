using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public static class ListExtesions
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

        public static IComparable ToNumberConverter<T>(T val)
        {
            return Type.GetTypeCode(val.GetType()) switch
            {
                TypeCode.Single => Convert.ToSingle(val),
                TypeCode.SByte => Convert.ToSByte(val),
                TypeCode.Byte => Convert.ToByte(val),
                TypeCode.Int16 => Convert.ToInt16(val),
                TypeCode.UInt16 => Convert.ToUInt16(val),
                TypeCode.Int32 => Convert.ToInt32(val),
                TypeCode.UInt32 => Convert.ToUInt32(val),
                TypeCode.Int64 => Convert.ToInt64(val),
                TypeCode.UInt64 => Convert.ToUInt64(val),
                TypeCode.Double => Convert.ToDouble(val),
                TypeCode.Decimal => Convert.ToDecimal(val),
                _ => 0,
            };
        }
    }
}
