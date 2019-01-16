using System;
using System.ComponentModel;

namespace Everything.NET.Library
{
    public class Resource
    {
        public ResourceType Type;
        public string Name;
        public long Size;
        public DateTime ModifiedTime;

        public Resource(RawResult)
        {

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