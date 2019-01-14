using CommandLine;
using System;
using System.Collections.Generic;

namespace Everything.NET.Verbs
{
    [Verb("download", HelpText = "Download a single file or every files under a folder.")]
    public class DownloadVerb: VerbBase
    {
        [Value(0, Required = true, HelpText = "Target URI.")]
        public String Uri { get; set; }
    }
}