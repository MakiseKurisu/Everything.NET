using CommandLine;
using CommandLine.Text;
using Everything.NET.Library.Actions;
using Everything.NET.Library.Types;
using Everything.NET.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everything.NET.Verbs
{
    [Verb("size", HelpText = "Return size of a given target.")]
    public class SizeVerb: CommonOption
    {
        [Usage]
        public static IEnumerable<Example> Examples => new List<Example>() {
                new Example("Return size of a given target.", new CommonOption { uri = @"http://www.example.com:8080/C:"})
            };

        public override async Task<object> Fetch()
        {
            return await SizeAction.Action(new Uri(uri),
            (folder, content) =>
            {
                WriteVerboseLine($"Found subfolder {folder.Uri.LocalPath} with {content.Count} pending resources.");
            });
        }

        public override async Task<int> Display(Task<object> obj)
        {
            var size = await obj as FileSize;
            if (size == null)
            {
                return await base.Display(obj);
            }

            WriteVerboseLine();

            WriteConsole($"Total Count: {size.Count}", Console.WindowWidth - 8 * 7);
            WriteConsole("Total Size:", 8 * 2);
            WriteConsole(size, 8 * 5);
            WriteConsoleLine();

            return 0;
        }
    }
}