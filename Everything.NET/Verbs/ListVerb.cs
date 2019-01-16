using CommandLine;
using CommandLine.Text;
using Everything.NET.Library;
using System;
using System.Collections.Generic;

namespace Everything.NET.Verbs
{
    [Verb("list", HelpText = "List all files under a folder.")]
    public class ListVerb: RequestParameter, IVerbBase
    {
        /// <summary>
        /// Target URI.
        /// </summary>
        protected Uri Uri;

        [Value(0, MetaName = "URI", Required = true, HelpText = "Target URI.")]
        public String _Uri { get => Uri.ToString(); set => Uri = new Uri(value); }

        [Usage]
        public static IEnumerable<Example> Examples
        {
            get => new List<Example>() {
                new Example("List all files under a folder.", new ListVerb { _Uri = @"http://www.example.com:8080/C:", _sort = "name", _ascending = 1 })
            };
        }

        public int Action()
        {
            using (var req = new Request(Uri))
            {
                var ret = req.Get(this);

                WriteConsole("Name", Console.WindowWidth - 8 * 6);
                WriteConsole("Type", 8);
                WriteConsole("Size", 16);
                WriteConsoleLine("Modified Date");

                foreach (var i in ret)
                {
                    WriteConsole(i.Name, Console.WindowWidth - 8 * 6);
                    WriteConsole(i.Type, 8);
                    WriteConsole(i.Size, 16);
                    WriteConsoleLine(i.ModifiedTime);
                }

                return 0;
            }
        }
    }
}
