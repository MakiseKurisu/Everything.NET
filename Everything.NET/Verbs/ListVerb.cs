using CommandLine;
using CommandLine.Text;
using Everything.NET.Library;
using System;
using System.Collections.Generic;

namespace Everything.NET.Verbs
{
    [Verb("list", HelpText = "List all files under a folder.")]
    public class ListVerb: VerbBase
    {
        [Value(0, MetaName = "URI", Required = true, HelpText = "Target URI.")]
        public String Uri { get; set; }

        [Usage]
        public static IEnumerable<Example> Examples
        {
            get => new List<Example>() {
                new Example("List all files under a folder.", new ListVerb { Uri = @"http://example.org" })
            };
        }

        public override int Action()
        {
            using (var req = new Request(Uri))
            {
                var param = new RequestParameter();

                var ret = req.Get(param);

                return 0;
            }
        }
    }
}
