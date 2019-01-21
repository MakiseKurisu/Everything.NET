using CommandLine;
using Everything.NET.Library.Types;
using Everything.NET.Verbs;
using System;
using System.Collections.Generic;

namespace Everything.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            Console.OutputEncoding = System.Text.Encoding.Unicode;
#if DEBUG
            if (args.Length == 0)
            {
                var known_hosts = new List<string>()
                {
                    @"http://www.amcc.ip.or.kr/",
                    @"http://xzcqy.com/",
                    @"http://39.104.190.48/",
                    @"http://173.12.200.6:8060/",
                };

                var host_path = new List<UniversalPath>()
                {
                    new UniversalPath(@"E:/뿌요뿌요2"),
                    new UniversalPath(@"C:/ngrok/nssm-2.24/src"),
                    new UniversalPath(@"C:/ngrok/nssm-2.24/src"),
                    new UniversalPath(@"C:/ngrok/nssm-2.24/src"),
                };

                var selected_host = 0;

                var tests = new List<string[]>()
                {
                    new string[] { "help" },
                    new string[] { "list", $"{known_hosts[selected_host]}{host_path[selected_host].UriPath}" },
                    new string[] { "size", $"{known_hosts[selected_host]}{host_path[selected_host].UriPath}", "--verbose", "1" },
                    new string[] { "search", $"{known_hosts[selected_host]}", "-s", host_path[selected_host].WindowsPath, "--size_column", "1", "--date_modified_column", "1", "--sort", "date_modified", "--verbose", "1", "--no_mime_type_check" },
                    new string[] { "download", $"{known_hosts[selected_host]}{host_path[selected_host].UriPath}" },
                };

                args = tests[3];
            }
#endif
            Parser.Default.ParseArguments<ListVerb, SizeVerb, SearchVerb>(args)
                .MapResult(
                  (IVerbBase opts) => opts.SetLibraryOption().Output().Result,
                  errs => 1);
        }

        static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            var ex = (Exception) args.ExceptionObject;
            Console.WriteLine($"{ex.ToString()}");
        }
    }
}
