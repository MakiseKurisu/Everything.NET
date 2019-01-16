using CommandLine;
using CommandLine.Text;
using Everything.NET.Library;
using System;
using System.Collections.Generic;

namespace Everything.NET.Verbs
{
    [Verb("search", HelpText = "Search files that match certein criteria.")]
    public class SearchVerb: SearchParameter, IVerbBase
    {
        [Usage]
        public static IEnumerable<Example> Examples
        {
            get => new List<Example>() {
                new Example("Search files that match certein criteria.", new SearchVerb { _Uri = @"http://www.example.com:8080/C:"})
            };
        }

        public int Action()
        {
            throw new NotImplementedException();
        }
    }
}