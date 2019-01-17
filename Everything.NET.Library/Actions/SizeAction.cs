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
        public static FileSize Action(Uri uri, Action<BaseResource, List<BaseResource>> lambda)
        {
            return ActionAsync(uri, lambda).Result;
        }

        public async static Task<FileSize> ActionAsync(Uri uri, Action<BaseResource, List<BaseResource>> lambda)
        {
            var parent = uri.LocateParent();

            var content = await Request.GetAsync(parent, new Types.Queries.BaseQuery());
            return await content.Find(r => (r.GetUri().Equals(uri))).GetSize(lambda);
        }
    }
}
