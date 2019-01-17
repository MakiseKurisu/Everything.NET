using Everything.NET.Library.Types.Queries;
using Everything.NET.Library.Types.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everything.NET.Library.Actions
{
    public class ListAction
    {
        public static List<BaseResource> Action(Uri uri, BaseQuery query)
        {
            return ActionAsync(uri, query).Result;
        }

        public static async Task<List<BaseResource>> ActionAsync(Uri uri, BaseQuery query)
        {
            using (var req = new Request(uri))
            {
                return await req.GetAsync(query);
            }
        }
    }
}
