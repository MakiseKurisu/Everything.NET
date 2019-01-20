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

        public UniversalPath Path { get; set; }
        public FileSize Size { get; set; }
        public DateTime ModifiedTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Attributes { get; set; }

        public Uri Location { get; set; }
        public Uri Uri => GetUri();
        public virtual Uri GetUri()
        {
            return new Uri(Location, Name);
        }

        public virtual async Task<FileSize> GetSize(Action<BaseResource, List<BaseResource>> lambda)
        {
            return await Task.Run<FileSize>(() => Size);
        }

        public BaseResource(RawResource obj)
        {
            Type = (BaseResourceType) Enum.Parse(typeof(BaseResourceType), obj.type, true);
            Name = obj.name;

            Path = new UniversalPath(obj.path ?? string.Empty);
            Size = new FileSize(string.IsNullOrEmpty(obj.size) ? 0 : Convert.ToUInt64(obj.size));
            ModifiedTime = string.IsNullOrEmpty(obj.date_modified) ? DateTime.MinValue : DateTime.FromFileTime(Convert.ToInt64(obj.date_modified));
            CreatedTime = string.IsNullOrEmpty(obj.date_created) ? DateTime.MinValue : DateTime.FromFileTime(Convert.ToInt64(obj.date_created));
            Attributes = obj.attributes ?? string.Empty;
        }

        public static List<BaseResource> FromRawQueryResult(Uri location, RawQueryResult r)
        {
            var uri = new UriBuilder(location)
            {
                Query = string.Empty
            };

            var list = new List<BaseResource>();
            foreach (var obj in r.results)
            {
                switch ((BaseResourceType) Enum.Parse(typeof(BaseResourceType), obj.type, true))
                {
                    case BaseResourceType.File:
                        {
                            list.Add(new FileResource(obj) { Location = uri.Uri });
                            break;
                        }
                    case BaseResourceType.Folder:
                        {
                            list.Add(new FolderResource(obj) { Location = uri.Uri });
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