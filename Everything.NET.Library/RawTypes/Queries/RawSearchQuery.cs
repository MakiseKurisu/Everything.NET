namespace Everything.NET.Library.RawTypes.Queries
{
    /// <summary>
    /// Define parameters used in Search
    /// See https://www.voidtools.com/support/everything/http/ for definition and default value
    /// </summary>
    public class RawSearchQuery : RawBaseRequest
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
        public uint @case;

        /// <summary>
        /// search whole words if value is nonzero
        /// </summary>
        public uint wholeword;

        /// <summary>
        /// search whole paths if value is nonzero
        /// </summary>
        public uint path;

        /// <summary>
        /// perform a regex search if value is nonzero
        /// </summary>
        public uint regex;

        /// <summary>
        /// match diacritics if value is nonzero
        /// </summary>
        public uint diacritics;

        /// <summary>
        /// list the result's path in the json object if value is nonzero
        /// </summary>
        public uint path_column;

        /// <summary>
        /// list the result's size in the json object if value is nonzero
        /// </summary>
        public uint size_column;

        /// <summary>
        /// list the result's modified date in the json object if value is nonzero
        /// </summary>
        public uint date_modified_column;

        /// <summary>
        /// list the result's creation date in the json object if value is nonzero
        /// </summary>
        public uint date_created_column;

        /// <summary>
        /// list the result's attributes in the json object if value is nonzero
        /// </summary>
        public uint attributes_column;

        public RawSearchQuery() : base()
        {
            search = "";
            offset = 0;
            count = 4294967295;
            @case = 0;
            wholeword = 0;
            path = 0;
            regex = 0;
            diacritics = 0;
            path_column = 0;
            size_column = 0;
            date_modified_column = 0;
            date_created_column = 0;
            attributes_column = 0;
        }

        public override string ToString()
        {
            return base.ToString()
                + $"search={search}&offset={offset}&count={count}"
                + $"&case={@case}&wholeword={wholeword}"
                + $"&path={path}&regex={regex}&diacritics={diacritics}"
                + $"&path_column={path_column}&size_column={size_column}"
                + $"&date_modified_column={date_modified_column}&date_created_column={date_created_column}"
                + $"&attributes_column={attributes_column}";
        }
    }
}
