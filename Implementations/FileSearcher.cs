using Delegates.Custom;
using Delegates.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Implementations
{
    public class FileSearcher(IConfiguration cfg, IOutput output) : IFileSearcher
    {
        private const string PathName = "Directory_";
        public event EventHandler<FileArgs>? FileFound;
        private readonly string _path = cfg.GetValue<string>(PathName);
        private readonly IOutput _output = output;

        public void Search(CancellationToken cancellation)
        {
            if (_path == null)
            {
                _output.WriteLine($"Couldn't read '{PathName}' key from configuration.");
                return;
            }
            var direcotry = new DirectoryInfo(_path);
            var files = direcotry.GetFiles();
            if (files.Any())
            {
                _output.WriteLine($"Start file dicovery in folder '{_path}'");
            }
            foreach (var file in files)
            {
                if (cancellation.IsCancellationRequested)
                {
                    return;
                }
                if (FileFound != null)
                {
                    FileFound.Invoke(this, new FileArgs(file.FullName));
                }
                Thread.Sleep(1000);
            }
        }
    }
}
