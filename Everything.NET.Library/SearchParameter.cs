using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everything.NET.Library
{
    /// <summary>
    /// Define parameters used in Search
    /// See https://www.voidtools.com/support/everything/http/ for definition and default value
    /// </summary>
    public class SearchParameter: RequestParameter
    {
        /// <summary>
        /// search text
        /// </summary>
        public string search;

        /// <summary>
        /// display results from the nth result
        /// </summary>
        public uint offset;

        /// <summary>
        /// return no more than value results
        /// </summary>
        public uint count;

        /// <summary>
        /// match case if value is nonzero
        /// </summary>
        public bool @case;

        /// <summary>
        /// search whole words if value is nonzero
        /// </summary>
        public bool wholeword;

        /// <summary>
        /// search whole paths if value is nonzero
        /// </summary>
        public bool path;

        /// <summary>
        /// perform a regex search if value is nonzero
        /// </summary>
        public bool regex;

        /// <summary>
        /// match diacritics if value is nonzero
        /// </summary>
        public bool diacritics;

        /// <summary>
        /// list the result's path in the json object if value is nonzero
        /// </summary>
        public bool path_column;

        /// <summary>
        /// list the result's size in the json object if value is nonzero
        /// </summary>
        public bool size_column;

        /// <summary>
        /// list the result's modified date in the json object if value is nonzero
        /// </summary>
        public bool date_modified_column;

        /// <summary>
        /// list the result's creation date in the json object if value is nonzero
        /// </summary>
        public bool date_created_column;

        /// <summary>
        /// list the result's attributes in the json object if value is nonzero
        /// </summary>
        public bool attributes_column;

        public SearchParameter() : base()
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
                + $"search={search}&offset={offset}&count={count}"
                + $"&case={Convert.ToInt32(@case)}&wholeword={Convert.ToInt32(wholeword)}"
                + $"&path={Convert.ToInt32(path)}&regex={Convert.ToInt32(regex)}&diacritics={Convert.ToInt32(diacritics)}"
                + $"&path_column={Convert.ToInt32(path_column)}&size_column={Convert.ToInt32(size_column)}"
                + $"&date_modified_column={Convert.ToInt32(date_modified_column)}&date_created_column={Convert.ToInt32(date_created_column)}"
                + $"&attributes_column={Convert.ToInt32(attributes_column)}";
        }
    }
}
