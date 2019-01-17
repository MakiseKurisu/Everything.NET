using CommandLine;
using System.ComponentModel;

namespace Everything.NET
{
    public class ListOption: CommonOption
    {
        [Option('j', "json", Default = 1, HelpText = "Return results as a JSON object if value is nonzero.", Hidden = true, Required = false)]
        public uint json { get; set; }

        [Option("sort", Default = "name", HelpText = "Where value can be one of the following: name, path, date_modified, or size.", Hidden = false, Required = false)]
        public string sort { get; set; }

        [Option("ascending", Default = 1, HelpText = "Sort by ascending order if value is nonzero.", Hidden = false, Required = false)]
        public uint ascending { get; set; }
    }

    public enum RequestParameterSortOption
    {
        /// <summary>
        /// Sort by Name.
        /// </summary>
        [Description("name")]
        name,

        /// <summary>
        /// Sort by Path.
        /// </summary>
        [Description("path")]
        path,

        /// <summary>
        /// Sort by Date Modified.
        /// </summary>
        [Description("date_modified")]
        date_modified,

        /// <summary>
        /// Sort by Size.
        /// </summary>
        [Description("size")]
        size,
    }
}
