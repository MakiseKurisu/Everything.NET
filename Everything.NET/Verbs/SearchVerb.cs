using CommandLine;
using CommandLine.Text;
using Everything.NET.Library.Actions;
using Everything.NET.Options;
using Everything.NET.Library.Types.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everything.NET.Verbs
{
    [Verb("search", HelpText = "Search files that match certein criteria.")]
    public class SearchVerb: SearchOption, IVerbBase
    {
        [Usage]
        public static IEnumerable<Example> Examples => new List<Example>() {
                new Example("Search files that match certein criteria.", new SearchOption { uri = @"http://www.example.com:8080/C:"})
            };

        public async Task<int> Action()
        {
            return await Print(SearchAction.Action(new Uri(uri), new SearchQuery(this)));
        }
    }
}