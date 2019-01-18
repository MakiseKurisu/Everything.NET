using CommandLine;
using CommandLine.Text;
using Everything.NET.Library.Actions;
using Everything.NET.Library.Types;
using Everything.NET.Library.Types.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everything.NET.Verbs
{
    [Verb("search", HelpText = "Search files that match certein criteria.")]
    public class SearchVerb: SearchOption, IVerbBase
    {
        [Usage]
        public static IEnumerable<Example> Examples => new List<Example>() {
                new Example("Search files that match certein criteria.", new SearchOption { uri = @"http://www.example.com:8080/C:"})
            };

        public async Task<int> Action()
        {
            var start = new TimeSpan(DateTime.Now.Ticks);

            var task = SearchAction.Action(new Uri(uri), new SearchQuery(this));

            WriteVerbose("Name", Console.WindowWidth - 8 * 6);
            WriteVerbose("Type", 8);
            WriteVerbose("Size", 8 * 2);
            WriteVerboseLine("Modified Date");

            var ret = await task;
            var size = new FileSize();
            foreach (var i in ret)
            {
                size += i.Size;

                WriteVerbose(i.Name, Console.WindowWidth - 8 * 6);
                WriteVerbose(i.Type, 8);
                WriteVerbose(i.Size, 8 * 2);
                WriteVerboseLine(i.ModifiedTime);
            }

            var end = new TimeSpan(DateTime.Now.Ticks);

            WriteVerboseLine();

            WriteVerboseLine($"Operation completed in {end - start}.");

            WriteConsole($"Total Count: {size.Count}", Console.WindowWidth - 8 * 7);
            WriteConsole("Total Size:", 8 * 2);
            WriteConsole(size, 8 * 5);
            WriteConsoleLine();

            return 0;
        }
    }
}