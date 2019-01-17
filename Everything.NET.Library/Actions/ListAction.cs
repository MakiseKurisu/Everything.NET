using Everything.NET.Library.Types;
using Everything.NET.Library.Types.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everything.NET.Library.Actions
{
    public class ListAction
    {
        public static List<Resource> Action(string uri, BaseQuery query)
        {
            return ActionAsync(uri, query).Result;
        }

        public static async Task<List<Resource>> ActionAsync(string uri, BaseQuery query)
        {
            using (var req = new Request(uri))
            {
                var ret = await req.GetAsync(query);
                return ret;
            }
        }
    }
}
