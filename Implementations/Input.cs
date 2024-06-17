using Delegates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Implementations
{
    public class ConsoleInput : IInput
    {
        public char ReadKey()
        {
            return Console.ReadKey().KeyChar;
        }
    }
}
