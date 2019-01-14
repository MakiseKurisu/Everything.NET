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
        /// return results as a JSON object if value is nonzero
        /// </summary>
        public bool json;

        /// <summary>
        /// where value can be one of the following: name, path, date_modified, or size
        /// </summary>
        public RequestParameterSortOption sort;

        /// <summary>
        /// sort by ascending order if value is nonzero
        /// </summary>
        public bool ascending;

        public RequestParameter()
        {
            json = true;
            sort = RequestParameterSortOption.name;
            ascending = true;
        }

        public override string ToString()
        {
            return $"json={Convert.ToInt32(json)}&sort={sort.ToString()}&ascending={Convert.ToInt32(ascending)}";
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

    public static class RequestParameterSortOptionExtensions
    {
        public static string ToString(this RequestParameterSortOption val)
        {
            var attributes = (DescriptionAttribute[]) val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
