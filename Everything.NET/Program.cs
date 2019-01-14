﻿using CommandLine;
using Everything.NET.Verbs;
using System;

namespace Everything.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    //args = new string[] { "help" };
                    args = new string[] { "list", @"http://www.amcc.ip.or.kr" };
                }

                Parser.Default.ParseArguments<DownloadVerb, ListVerb>(args)
                    .MapResult(
                      (DownloadVerb opts) => opts.Action(),
                      (ListVerb opts) => opts.Action(),
                      errs => 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.ToString()}");
            }
        }
    }
}
