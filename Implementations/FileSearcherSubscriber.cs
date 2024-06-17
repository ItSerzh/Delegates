using Delegates.Custom;
using Delegates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Implementations
{
    public class FileSearcherSubscriber : IFileSearcherSubscriber, IDisposable
    {
        private readonly IFileSearcher _searcher;
        private readonly IOutput _output;

        public FileSearcherSubscriber(IFileSearcher searcher, IOutput output)
        {
            _searcher = searcher;
            _searcher.FileFound += HandleFileFound;
            _output = output;
        }

        public void Unsubscribe()
        {
            _searcher.FileFound -= HandleFileFound;
        }

        private void HandleFileFound(object? sender, FileArgs args)
        {
            _output.WriteLine($"Found file: {args.FilePath}");
        }

        public void Dispose()
        {
            Unsubscribe();
        }
    }
}
