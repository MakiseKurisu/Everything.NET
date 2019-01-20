using CommandLine;
using CommandLine.Text;
using Everything.NET.Library.Actions;
using Everything.NET.Library.Types.Queries;
using Everything.NET.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everything.NET.Verbs
{
    [Verb("list", HelpText = "List all files under a folder.")]
    public class ListVerb: ListOption
    {
        [Usage]
        public static IEnumerable<Example> Examples => new List<Example>() {
                new Example("List all files under a folder.", new ListOption { uri = @"http://www.example.com:8080/C:", sort = "name", ascending = 1 })
            };

        public override async Task<int> Action()
        {
            return await Print(ListAction.Action(new Uri(uri), new BaseQuery(this)));
        }
    }
}
