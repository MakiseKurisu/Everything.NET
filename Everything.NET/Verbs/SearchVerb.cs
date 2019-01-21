using CommandLine;
using CommandLine.Text;
using Everything.NET.Library.Actions;
using Everything.NET.Options;
using Everything.NET.Library.Types.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Everything.NET.Library.Types.Resources;

namespace Everything.NET.Verbs
{
    [Verb("search", HelpText = "Search files that match certein criteria.")]
    public class SearchVerb: SearchOption
    {
        [Usage]
        public static IEnumerable<Example> Examples => new List<Example>() {
                new Example("Search files that match certein criteria.", new SearchOption { uri = @"http://www.example.com:8080/C:"})
            };

        public override async Task<object> Fetch()
        {
            var u = new Uri(uri);
            var stream = await SearchAction.Action(u, new SearchQuery(this));
            var contents = BaseResource.FromStream(u, stream);
                
            return contents;
        }
    }
}