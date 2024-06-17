using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Custom
{
    public class FileArgs(string path) : EventArgs
    {
        private readonly string _path = path;

        public string FilePath { get { return _path; } }
    }
}
