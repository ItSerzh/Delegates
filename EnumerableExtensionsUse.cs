using Delegates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class EnumerableExtensionsUse<T>(IOutput output)
    {
        private readonly IOutput _output = output;

        public void CheckListMax(List<T> list)
        {
            var result = list.GetMax<IComparable>(ToNumber);
            _output.WriteLine($"For list of type{typeof(T)} max value is {result}");
        }

        public IComparable ToNumber<T>(T val)
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
