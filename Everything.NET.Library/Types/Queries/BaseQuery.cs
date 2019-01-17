using Everything.NET.Library.RawTypes.Queries;
using System;
using System.ComponentModel;

namespace Everything.NET.Library.Types.Queries
{
    /// <summary>
    /// Define parameters used in Search
    /// See https://www.voidtools.com/support/everything/http/ for definition and default value
    /// </summary>
    public class BaseQuery
    {
        /// <summary>
        /// Return results as a JSON object if value is nonzero.
        /// </summary>
        public bool json;

        /// <summary>
        /// Where value can be one of the following: name, path, date_modified, or size.
        /// </summary>
        public BaseQuerySortOption sort;

        /// <summary>
        /// Sort by ascending order if value is nonzero.
        /// </summary>
        public bool ascending;

        public BaseQuery(RawBaseQuery raw)
        {
            json = Convert.ToBoolean(raw.json);
            var ret = Enum.TryParse(raw.sort, true, out sort);
            if (!ret)
            {
                throw new ArgumentOutOfRangeException("RawBaseQuery.sort", raw.sort, "Invalid value for RawBaseQuery.sort");
            }
            ascending = Convert.ToBoolean(raw.ascending);
        }

        public BaseQuery()
        {
            json = true;
            sort = BaseQuerySortOption.name;
            ascending = true;
        }

        public override string ToString()
        {
            return $"json={Convert.ToUInt32(json)}&sort={sort}&ascending={Convert.ToUInt32(ascending)}";
        }
    }

    public enum BaseQuerySortOption
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
