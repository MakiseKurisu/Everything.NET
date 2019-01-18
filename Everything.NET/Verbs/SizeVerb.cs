using CommandLine;
using CommandLine.Text;
using Everything.NET.Library.Actions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everything.NET.Verbs
{
    [Verb("size", HelpText = "Return size of a given target.")]
    public class SizeVerb: CommonOption, IVerbBase
    {
        [Usage]
        public static IEnumerable<Example> Examples
        {
            get => new List<Example>() {
                new Example("Return size of a given target.", new CommonOption { uri = @"http://www.example.com:8080/C:"})
            };
        }

        public async Task<int> Action()
        {
            var start = new TimeSpan(DateTime.Now.Ticks);

            var target = new Uri(uri);
            var task = SizeAction.Action(target, (folder, content) =>
            {
                WriteConsoleLine($"Found subfolder {folder.Uri.LocalPath} with {content.Count} pending resources.");
            });

            var size = await task;

            var end = new TimeSpan(DateTime.Now.Ticks);

            WriteConsoleLine();
            WriteConsoleLine($"Operation completed in {end - start}.");
            WriteConsoleLine($"Target {target.LocalPath} contains {size.Count} files, consuming {size} of storage space.");

            return 0;
        }
    }
}