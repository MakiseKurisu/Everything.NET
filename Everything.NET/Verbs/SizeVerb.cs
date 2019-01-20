using CommandLine;
using CommandLine.Text;
using Everything.NET.Library.Actions;
using System;
using System.Collections.Generic;
using Everything.NET.Options;
using System.Threading.Tasks;

namespace Everything.NET.Verbs
{
    [Verb("size", HelpText = "Return size of a given target.")]
    public class SizeVerb: CommonOption, IVerbBase
    {
        [Usage]
        public static IEnumerable<Example> Examples => new List<Example>() {
                new Example("Return size of a given target.", new CommonOption { uri = @"http://www.example.com:8080/C:"})
            };

        public async Task<int> Action()
        {
            var start = new TimeSpan(DateTime.Now.Ticks);

            var task = SizeAction.Action(new Uri(uri),
            (folder, content) =>
            {
                WriteVerboseLine($"Found subfolder {folder.Uri.LocalPath} with {content.Count} pending resources.");
            });

            var size = await task;

            var end = new TimeSpan(DateTime.Now.Ticks);

            WriteVerboseLine();

            WriteConsoleLine($"Operation completed in {end - start}.");

            WriteConsole($"Total Count: {size.Count}", Console.WindowWidth - 8 * 7);
            WriteConsole("Total Size:", 8 * 2);
            WriteConsole(size, 8 * 5);
            WriteConsoleLine();

            return 0;
        }
    }
}