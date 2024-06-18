using Delegates.Interfaces;
using System;
using System.Collections;
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
            if (result != null)
            {
                _output.WriteLine($"For list of type{typeof(T)} max value is {result}");
            }
            else
            {
                _output.WriteLine($"In list of type{typeof(T)} at least one item is not number");
            }
        }

        public float ToNumber<T>(T val)
        {
            return Convert.ToSingle(val);
        }
    }
}
