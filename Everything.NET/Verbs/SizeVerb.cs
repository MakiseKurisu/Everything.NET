using CommandLine;
using CommandLine.Text;
using Everything.NET.Library;
using System;
using System.Collections.Generic;

namespace Everything.NET.Verbs
{
    [Verb("size", HelpText = "Return size of a given target.")]
    public class SizeVerb: SearchParameter, IVerbBase
    {
        [Usage]
        public static IEnumerable<Example> Examples
        {
            get => new List<Example>() {
                new Example("Return size of a given target.", new SizeVerb { _Uri = @"http://www.example.com:8080/C:"})
            };
        }

        public int Action()
        {
            throw new NotImplementedException();
        }
    }
}