using CommandLine;
using Everything.NET.Verbs;
using System;

namespace Everything.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            Console.OutputEncoding = System.Text.Encoding.Unicode;

            if (args.Length == 0)
            {
                //args = new string[] { "help" };
                args = new string[] { "size", @"http://www.amcc.ip.or.kr/D:/주문토끼/" };
            }

            Parser.Default.ParseArguments<DownloadVerb, ListVerb, SearchVerb, SizeVerb>(args)
                .MapResult(
                  (IVerbBase opts) => opts.Action().Result,
                  errs => 1);
        }

        static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception ex = (Exception) args.ExceptionObject;
            Console.WriteLine($"{ex.ToString()}");
        }
    }
}
