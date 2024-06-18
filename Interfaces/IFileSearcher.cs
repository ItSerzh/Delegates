using Delegates.Custom;
using Delegates.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Interfaces
{
    public interface IFileSearcher
    {
        event EventHandler<FileArgs> FileFound;
        void Search(CancellationToken cancellation);
    }
}
