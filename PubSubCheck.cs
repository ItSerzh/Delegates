using Delegates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class PubSubCheck(IFileSearcher searcher, IFileSearcherSubscriber subscriber, IInput input, IOutput output)
    {
        public async Task CheckInteraction()
        {
            using (var cts = new CancellationTokenSource())
            {
                var keyBoardTask = Task.Run(() =>
                {
                    output.WriteLine("Press any key to cancel");
                    input.ReadKey();

                    cts.Cancel();
                    subscriber.Unsubscribe();
                    output.WriteLine("File discovery interrupted.");
                });

                var task = Task.Run(() => searcher.Search(cts));

                await task;
                await keyBoardTask;
            }
        }
    }
}
