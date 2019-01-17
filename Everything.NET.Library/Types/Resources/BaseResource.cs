using Everything.NET.Library.RawTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Everything.NET.Library.Types.Resources
{
    public class BaseResource
    {
        public BaseResourceType Type { get; set; }
        public string Name { get; set; }
        public FileSize Size { get; set; }
        public DateTime ModifiedTime { get; set; }

        public Uri Location { get; set; }
        public Uri Uri => GetUri();
        public virtual Uri GetUri() => new Uri(Location, Name);

        public async virtual Task<FileSize> GetSize(Action<BaseResource, List<BaseResource>> lambda) => await new Task<FileSize>(() => Size);

        public BaseResource(RawResource obj)
        {
            Type = (BaseResourceType) Enum.Parse(typeof(BaseResourceType), obj.type, true);
            Name = obj.name;

            if (String.IsNullOrEmpty(obj.size))
            {
                obj.size = "0";
            }
            Size = new FileSize(Convert.ToUInt64(obj.size));

            ModifiedTime = DateTime.FromFileTime(Convert.ToInt64(obj.date_modified));
        }

        public static List<BaseResource> FromRawQueryResult(Uri location, RawQueryResult r)
        {
            var uri = new UriBuilder(location)
            {
                Query = string.Empty
            };

            var list = new List<BaseResource>();
            foreach (var result in r.results)
            {
                switch ((BaseResourceType) Enum.Parse(typeof(BaseResourceType), result.type, true))
                {
                    case BaseResourceType.File:
                        {
                            list.Add(new FileResource(result) { Location = uri.Uri });
                            break;
                        }
                    case BaseResourceType.Folder:
                        {
                            list.Add(new FolderResource(result) { Location = uri.Uri });
                            break;
                        }
                }
            }
            return list;
        }
    }

    public enum BaseResourceType
    {
        /// <summary>
        /// Object is a file.
        /// </summary>
        [Description("file")]
        File,

        /// <summary>
        /// Object is a folder.
        /// </summary>
        [Description("folder")]
        Folder,
    }
}