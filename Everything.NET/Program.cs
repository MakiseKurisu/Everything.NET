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
#if DEBUG
            if (args.Length == 0)
            {
                //args = new string[] { "help" };
                //args = new string[] { "list", @"http://www.amcc.ip.or.kr/E:/BaiduNetdiskDownload/" };
                //args = new string[] { "size", @"http://www.amcc.ip.or.kr/E:/BaiduNetdiskDownload/", "--verbose", "1" };
                args = new string[] { "search", @"http://www.amcc.ip.or.kr/", "-s", @"E:\BaiduNetDIskDownload", "--size_column", "1", "--date_modified_column", "1", "--sort", "date_modified", "--verbose", "1" };
                //args = new string[] { "download", @"http://www.amcc.ip.or.kr/E:/금서목록 3기/" };
            }
#endif
            Parser.Default.ParseArguments< ListVerb, SizeVerb, SearchVerb>(args)
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
