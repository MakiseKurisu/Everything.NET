using CommandLine;
using System;

namespace Everything.NET.Library
{
    public class CommonParameter
    {
        [Option('w', "width", Default = 20, HelpText = "Set column size.", Hidden = false, Required = false)]
        public int _Width { get; set; }

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

        public void WriteConsoleLine<T>(T text)
        {
            Console.WriteLine(text.ToString());
        }
    }
}
