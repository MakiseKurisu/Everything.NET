﻿using Everything.NET.Library.RawTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Everything.NET.Library.Types.Resources
{
    public class BaseResource
    {
        public BaseResourceType Type { get; set; }
        public string Name { get; set; }
        public virtual FileSize Size { get; set; }
        public DateTime ModifiedTime { get; set; }

        public Uri Uri { get; set; }

        public BaseResource(RawResource obj)
        {
            BaseResourceType type;
            if (!Enum.TryParse(obj.type, true, out type))
            {
                throw new ArgumentException("Invalid ResourceType enum.", "obj.type");
            }
            else
            {
                Type = type;
            }

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
            var list = new List<BaseResource>();
            foreach (var result in r.results)
            {
                BaseResourceType type;
                if (!Enum.TryParse(result.type, true, out type))
                {
                    throw new ArgumentException("Invalid ResourceType enum.", "obj.type");
                }

                switch (type)
                {
                    case BaseResourceType.File:
                        {
                            list.Add(new FileResource(result) { Uri = location });
                            break;
                        }
                    case BaseResourceType.Folder:
                        {
                            list.Add(new FolderResource(result) { Uri = location });
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