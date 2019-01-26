using CommandLine;
using CommandLine.Text;
using Everything.NET.Library.Actions;
using Everything.NET.Library.Types.Queries;
using Everything.NET.Library.Types.Resources;
using Everything.NET.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everything.NET.Verbs
{
    [Verb("download", HelpText = "Download a single file or every files under a folder.")]
    public class DownloadVerb: ListOption
    {
        [Usage]
        public static IEnumerable<Example> Examples => new List<Example>() {
                new Example("Download a single file or every files under a folder.", new CommonOption { uri = @"http://www.example.com:8080/C:"})
            };

        public override async Task<object> Fetch()
        {
            return await DownloadAction.Action(new Uri(uri), new BaseQuery(this), x =>
            {
                switch (x.Type)
                {
                    case BaseResourceType.File:
                        {
                            WriteVerboseLine($"Start downloading {x.Name}, size {x.Size}.");
                            break;
                        }
                    case BaseResourceType.Folder:
                        {
                            WriteVerboseLine($"Enter folder {x.Name}.");
                            break;
                        }
                }
            });
        }

        public override async Task<int> Display(Task<object> obj)
        {
            WriteConsoleLine($"Download completed.");
            return 0;
        }
    }
}