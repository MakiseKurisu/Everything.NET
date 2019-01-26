using Everything.NET.Library.Types.Queries;
using Everything.NET.Library.Types.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Everything.NET.Library.Actions
{
    public class DownloadAction
    {
        public static async Task<bool> Action(Uri uri, BaseQuery query, Action<BaseResource> callback)
        {
            callback(new BaseResource(uri));

            List<BaseResource> contents;

            using (var stream = await ListAction.Action(uri, query))
            {
                contents = BaseResource.FromStream(uri, stream);
            }

            var progress = new List<Task>();

            foreach (var i in contents.Where(x => x.Type == BaseResourceType.File))
            {
                progress.Add(Task.Run(async () =>
                {
                    callback(i);

                    using (var s = await Request.Get(i.Uri, query))
                    using (var fs = File.Create(i.Path.WindowsSubfolderPath))
                    {
                        s.Seek(0, SeekOrigin.Begin);
                        s.CopyTo(fs);
                    }
                }));
            }

            await Task.WhenAll(progress);
            progress.Clear();

            foreach (var i in contents.Where(x => x.Type == BaseResourceType.Folder))
            {
                progress.Add(DownloadAction.Action(i.Uri, query, callback));
            }

            await Task.WhenAll(progress);
            progress.Clear();

            return true;
        }
    }
}
