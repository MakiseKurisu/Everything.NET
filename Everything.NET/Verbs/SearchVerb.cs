using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everything.NET.Verbs
{
    [Verb("search", HelpText = "Search files that match certein criteria.")]
    public class SearchVerb: SearchOption, IVerbBase
    {
        [Usage]
        public static IEnumerable<Example> Examples
        {
            get => new List<Example>() {
                new Example("Search files that match certein criteria.", new SearchOption { uri = @"http://www.example.com:8080/C:"})
            };
        }

        public async Task<int> Action()
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }
    }
}