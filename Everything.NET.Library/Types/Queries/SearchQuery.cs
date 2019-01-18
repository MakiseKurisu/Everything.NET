using Everything.NET.Library.RawTypes.Queries;
using System;

namespace Everything.NET.Library.Types.Queries
{
    /// <summary>
    /// Define parameters used in Search
    /// See https://www.voidtools.com/support/everything/http/ for definition and default value
    /// </summary>
    public class SearchQuery: BaseQuery
    {
        public string search;

        public uint offset;

        public uint count;

        public bool @case;

        public bool wholeword;

        public bool path;

        public bool regex;

        public bool diacritics;

        public bool path_column;

        public bool size_column;

        public bool date_modified_column;

        public bool date_created_column;

        public bool attributes_column;

        public SearchQuery(RawSearchQuery raw) : base(raw)
        {
            search = raw.search;
            offset = raw.offset;
            count = raw.count;
            @case = Convert.ToBoolean(raw.@case);
            wholeword = Convert.ToBoolean(raw.wholeword);
            path = Convert.ToBoolean(raw.path);
            regex = Convert.ToBoolean(raw.regex);
            diacritics = Convert.ToBoolean(raw.diacritics);
            path_column = Convert.ToBoolean(raw.path_column);
            size_column = Convert.ToBoolean(raw.size_column);
            date_modified_column = Convert.ToBoolean(raw.date_modified_column);
            date_created_column = Convert.ToBoolean(raw.date_created_column);
            attributes_column = Convert.ToBoolean(raw.attributes_column);
        }

        public SearchQuery() : base()
        {
            search = "";
            offset = 0;
            count = 4294967295;
            @case = false;
            wholeword = false;
            path = false;
            regex = false;
            diacritics = false;
            path_column = false;
            size_column = false;
            date_modified_column = false;
            date_created_column = false;
            attributes_column = false;
        }

        public override string ToString()
        {
            return base.ToString()
                + $"&search={search}&offset={offset}&count={count}"
                + $"&case={Convert.ToUInt32(@case)}&wholeword={Convert.ToUInt32(wholeword)}"
                + $"&path={Convert.ToUInt32(path)}&regex={Convert.ToUInt32(regex)}&diacritics={Convert.ToUInt32(diacritics)}"
                + $"&path_column={Convert.ToUInt32(path_column)}&size_column={Convert.ToUInt32(size_column)}"
                + $"&date_modified_column={Convert.ToUInt32(date_modified_column)}&date_created_column={Convert.ToUInt32(date_created_column)}"
                + $"&attributes_column={Convert.ToUInt32(attributes_column)}";
        }
    }
}
