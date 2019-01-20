using CommandLine;
using Everything.NET.Library.Types;
using Everything.NET.Library.Types.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everything.NET.Options
{
    public class CommonOption: CompatibilityOption
    {
        [Value(0, MetaName = "uri", Required = true, HelpText = "Target URI.")]
        public string uri { get; set; }

        [Option("verbose", Default = false, HelpText = "Display the extra information.", Hidden = false, Required = false)]
        public bool verbose { get; set; }

        [Option("save_response", Default = "", HelpText = "Save the raw response to the given location. Suppress output.", Hidden = false, Required = false)]
        public string save_response { get; set; }

        public bool WriteConsole<T>(T text, int padding)
        {
            padding = padding < 0 ? 0 : padding;

            var cur = Console.CursorLeft;
            Console.Write(text.ToString());

            var end = cur + padding;
            if (end <= Console.WindowWidth)
            {
                if (Console.CursorLeft < end)
                {
                    Console.Write(new string(' ', end - Console.CursorLeft));
                }
                else
                {
                    Console.WriteLine();
                    Console.CursorLeft = end;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void WriteConsole<T>(T text)
        {
            Console.Write(text.ToString());
        }

        public void WriteConsoleLine()
        {
            Console.WriteLine();
        }

        public void WriteConsoleLine<T>(T text)
        {
            Console.WriteLine(text.ToString());
        }

        public bool WriteVerbose<T>(T text, int padding)
        {
            if (verbose)
            {
                return WriteConsole(text, padding);
            }
            else
            {
                return true;
            }
        }

        public void WriteVerboseLine()
        {
            if (verbose)
            {
                Console.WriteLine();
            }
        }

        public void WriteVerboseLine<T>(T text)
        {
            if (verbose)
            {
                Console.WriteLine(text.ToString());
            }
        }

        public async Task<int> Print(Task<List<BaseResource>> resources)
        {
            var start = new TimeSpan(DateTime.Now.Ticks);

            var size = new FileSize();

            WriteVerbose("Name", Console.WindowWidth - 8 * 6);
            WriteVerbose("Type", 8);
            WriteVerbose("Size", 8 * 2);
            WriteVerboseLine("Modified Date");

            var ret = await resources;
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

            WriteConsoleLine($"Operation completed in {end - start}.");

            WriteConsole($"Total Count: {size.Count}", Console.WindowWidth - 8 * 7);
            WriteConsole("Total Size:", 8 * 2);
            WriteConsole(size, 8 * 5);
            WriteConsoleLine();

            return 0;
        }
    }
}
