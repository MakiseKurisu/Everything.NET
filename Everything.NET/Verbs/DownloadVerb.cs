using CommandLine;
using CommandLine.Text;
using Everything.NET.Library;
using System;
using System.Collections.Generic;

namespace Everything.NET.Verbs
{
    [Verb("download", HelpText = "Download a single file or every files under a folder.")]
    public class DownloadVerb: RequestParameter, IVerbBase
    {
        [Usage]
        public static IEnumerable<Example> Examples
        {
            get => new List<Example>() {
                new Example("Download a single file or every files under a folder.", new DownloadVerb { _Uri = @"http://www.example.com:8080/C:"})
            };
        }

        public int Action()
        {
            throw new NotImplementedException();
        }
    }
}