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

        public override FileSize GetSize(Action<BaseResource, List<BaseResource>> lambda)
        {
            var contents = ListAction.Action(GetUri(), new Queries.BaseQuery());
            lambda(this, contents);

            var sizeLock = new object();
            Parallel.ForEach(contents, c =>
            {
                lock (sizeLock)
                {
                    Size += c.GetSize(lambda);
                }
            });
            return Size;
        }

        public FolderResource(RawResource obj) : base(obj) { }
    }
}
