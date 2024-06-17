using Delegates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Implementations
{
    public class ConsoleOutput : IOutput
    {
        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
    }
}
