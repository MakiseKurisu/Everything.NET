using Everything.NET.Library.Types.Queries;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Everything.NET.Library.Actions
{
    public class SearchAction
    {
        public static async Task<Stream> Action(Uri uri, SearchQuery query)
        {
            return await Request.Get(uri, query);
        }
    }
}
