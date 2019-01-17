using CommandLine;
using CommandLine.Text;
using Everything.NET.Library;
using Everything.NET.Library.Types.Queries;
using System;
using System.Collections.Generic;

namespace Everything.NET.Verbs
{
    [Verb("list", HelpText = "List all files under a folder.")]
    public class ListVerb: ListOption, IVerbBase
    {
        [Usage]
        public static IEnumerable<Example> Examples
        {
            get => new List<Example>() {
                new Example("List all files under a folder.", new ListOption { uri = @"http://www.example.com:8080/C:", sort = "name", ascending = 1 })
            };
        }

        public int Action()
        {
            using (var req = new Request(uri))
            {
                var ret = req.Get(new BaseQuery(this));

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
