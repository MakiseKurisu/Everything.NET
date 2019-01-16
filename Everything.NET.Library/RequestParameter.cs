using CommandLine;
using System;
using System.ComponentModel;

namespace Everything.NET.Library
{
    /// <summary>
    /// Define parameters used in Request
    /// See https://www.voidtools.com/support/everything/http/ for definition and default value
    /// </summary>
    public class RequestParameter
    {
        /// <summary>
        /// Return results as a JSON object if value is nonzero.
        /// </summary>
        protected bool json;

        [Option('j', "json", Default = 1, HelpText = "Return results as a JSON object if value is nonzero.", Hidden = true, Required = false)]
        public int _json { get => Convert.ToInt32(json); set => json = Convert.ToBoolean(value); }

        /// <summary>
        /// Where value can be one of the following: name, path, date_modified, or size.
        /// </summary>
        protected RequestParameterSortOption sort;

        [Option('s', "sort", Default = "name", HelpText = "Where value can be one of the following: name, path, date_modified, or size.", Hidden = false, Required = false)]
        public string _sort
        {
            get => Enum.GetName(typeof(RequestParameterSortOption), sort);
            set => sort = Enum.TryParse(value, true, out sort) ? sort : RequestParameterSortOption.name;
        }

        /// <summary>
        /// Sort by ascending order if value is nonzero.
        /// </summary>
        protected bool ascending;

        [Option('a', "ascending", Default = 1, HelpText = "Sort by ascending order if value is nonzero.", Hidden = false, Required = false)]
        public int _ascending { get => Convert.ToInt32(ascending); set => ascending = Convert.ToBoolean(value); }

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
