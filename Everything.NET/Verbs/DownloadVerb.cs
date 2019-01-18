﻿using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everything.NET.Verbs
{
    [Verb("download", HelpText = "Download a single file or every files under a folder.")]
    public class DownloadVerb: CommonOption, IVerbBase
    {
        [Usage]
        public static IEnumerable<Example> Examples
        {
            get => new List<Example>() {
                new Example("Download a single file or every files under a folder.", new CommonOption { uri = @"http://www.example.com:8080/C:"})
            };
        }

        public async Task<int> Action()
        {
            throw new NotImplementedException();
        }
    }
}