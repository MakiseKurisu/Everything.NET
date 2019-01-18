using CommandLine;
using System;

namespace Everything.NET
{
    public class CommonOption
    {
        [Value(0, MetaName = "uri", Required = true, HelpText = "Target URI.")]
        public string uri { get; set; }

        [Option("verbose", Default = false, HelpText = "Display the extra information.", Hidden = false, Required = false)]
        public bool verbose { get; set; }

        [Option("save_response", Default = "", HelpText = "Save the raw response to the given location.", Hidden = false, Required = false)]
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
    }
}
