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

                Console.WriteLine($"Name\t\t\t\t\t\t\t\t\tType\tSize\t\tModified Date");

                foreach (var i in ret)
                {
                    Console.Write($"{i.Name}");
                    if (Console.CursorLeft < 72)
                    {
                        Console.Write(new string(' ', 72 - Console.CursorLeft));
                    }
                    Console.Write($"{i.Type}\t{i.Size}");
                    if (Console.CursorLeft < 96)
                    {
                        Console.Write(new string(' ', 96 - Console.CursorLeft));
                    }
                    Console.WriteLine($"{i.ModifiedTime}");
                }

                return 0;
            }
        }
    }
}
