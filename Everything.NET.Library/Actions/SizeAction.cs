using Everything.NET.Library.Extensions;
using Everything.NET.Library.Types;
using Everything.NET.Library.Types.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everything.NET.Library.Actions
{
    public class SizeAction
    {
        public async static Task<FileSize> Action(Uri uri, Action<BaseResource, List<BaseResource>> lambda)
        {
            var parent = uri.LocateParent();

            var content = await Request.Get(parent, new Types.Queries.BaseQuery());
            var resource = content.Find(r => (r.GetUri().Equals(uri)));

            return await resource.GetSize(lambda);
        }
    }
}
