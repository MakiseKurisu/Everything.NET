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

        public async override Task<FileSize> GetSize(Action<BaseResource, List<BaseResource>> lambda)
        {
            List<BaseResource> contents;

            await Request.GetLock();
            try
            {
                contents = await ListAction.Action(GetUri(), new Queries.BaseQuery());
            }
            finally
            {
                Request.ReleaseLock();
            }

            lambda(this, contents);

            var subfolder = new List<Task>();
            foreach (var c in contents)
            {
                subfolder.Add(Task.Run(async ()=>
                {
                    var s = await c.GetSize(lambda);
                    var sizeLock = new object();
                    lock(sizeLock)
                    {
                        Size += s;
                    }

                }));
            }
            await Task.WhenAll(subfolder);
            return Size;
        }

        public FolderResource(RawResource obj) : base(obj) { }
    }
}
