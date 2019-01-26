using CommandLine;
using CommandLine.Text;
using Everything.NET.Library.Actions;
using Everything.NET.Library.Types.Queries;
using Everything.NET.Library.Types.Resources;
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

        public override async Task<object> Fetch()
        {
            var u = new Uri(uri);
            using (var stream = await ListAction.Action(u, new BaseQuery(this)))
            {
                return BaseResource.FromStream(u, stream);
            }
        }
    }
}
