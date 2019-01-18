﻿using Everything.NET.Library.Types.Queries;
using Everything.NET.Library.Types.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everything.NET.Library.Actions
{
    public class SearchAction
    {
        public static async Task<List<BaseResource>> Action(Uri uri, SearchQuery query)
        {
            return await Request.Get(uri, query);
        }
    }
}
