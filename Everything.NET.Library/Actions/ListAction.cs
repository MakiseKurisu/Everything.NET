using Everything.NET.Library.Types.Queries;
using Everything.NET.Library.Types.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Everything.NET.Library.Actions
{
    public class ListAction
    {
        public static async Task<Stream> Action(Uri uri, BaseQuery query)
        {
            return await Request.Get(uri, query); 
        }
    }
}
