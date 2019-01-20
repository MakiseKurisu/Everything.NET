﻿using Everything.NET.Library.Types.Queries;
using Everything.NET.Library.Types.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everything.NET.Library.Actions
{
    public class ListAction
    {
        public static async Task<List<BaseResource>> Action(Uri uri, BaseQuery query)
        {
            var stream = await Request.Get(uri, query);
            return BaseResource.FromStream(uri, stream);
        }
    }
}
