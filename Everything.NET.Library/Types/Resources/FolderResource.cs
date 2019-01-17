using Everything.NET.Library.Actions;
using Everything.NET.Library.RawTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everything.NET.Library.Types.Resources
{
    public class FolderResource: BaseResource
    {
        public override Uri GetUri()
        {
            var uri = new UriBuilder(Location);
            uri.Path += Name + "/";
            return uri.Uri;
        }

        public override async Task<FileSize> GetSize(Action<BaseResource, List<BaseResource>> lambda)
        {
            var contents = await ListAction.ActionAsync(GetUri(), new Queries.BaseQuery());
            lambda(this, contents);

            var sizeLock = new object();
            Parallel.ForEach(contents, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, c =>
            {
                var s = c.GetSize(lambda).Result;
                lock (sizeLock)
                {
                    Size += s;
                }
            });
            return Size;
        }

        public FolderResource(RawResource obj) : base(obj) { }
    }
}
