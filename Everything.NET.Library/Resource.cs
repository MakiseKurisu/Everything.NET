using Everything.NET.Library.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Everything.NET.Library
{
    public class Resource
    {
        public ResourceType Type;
        public string Name;
        public FileSize Size;
        public DateTime ModifiedTime;

        public Resource(RawResult obj)
        {
            if (!Enum.TryParse(obj.type, true, out Type))
            {
                throw new ArgumentException("Invalid ResourceType enum.", "obj.type");
            }

            Name = obj.name;

            if (String.IsNullOrEmpty(obj.size))
            {
                obj.size = "0";
            }
            Size = new FileSize(Convert.ToUInt64(obj.size));

            ModifiedTime = DateTime.FromFileTime(Convert.ToInt64(obj.date_modified));
        }

        public static List<Resource> FromRawResults(RawResults r)
        {
            var list = new List<Resource>();
            foreach (var result in r.results)
            {
                list.Add(new Resource(result));
            }
            return list;
        }
    }

    public enum ResourceType
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