using CommandLine;
using Everything.NET.Library.RawTypes.Queries;
using System;
using System.ComponentModel;

namespace Everything.NET.Library
{
    public class RequestParameter: RawBaseRequest
    {
        [Option('j', "json", Default = true, HelpText = "Return results as a JSON object if value is nonzero.", Hidden = true, Required = false)]
        public bool _json { get; set; }

        [Option('s', "sort", Default = "name", HelpText = "Where value can be one of the following: name, path, date_modified, or size.", Hidden = false, Required = false)]
        public string _sort { get; set; }

        [Option('a', "ascending", Default = true, HelpText = "Sort by ascending order if value is nonzero.", Hidden = false, Required = false)]
        public int _ascending { get; set; }

        public override string ToString()
        {
            return $"json={_json}&sort={_sort}&ascending={_ascending}";
        }
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
