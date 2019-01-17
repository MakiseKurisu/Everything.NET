namespace Everything.NET.Library.RawTypes.Queries
{
    /// <summary>
    /// Define parameters used in Search
    /// See https://www.voidtools.com/support/everything/http/ for definition and default value
    /// </summary>
    public interface RawSearchQuery: RawBaseQuery
    {
        /// <summary>
        /// search text
        /// </summary>
        string search { get; set; }

        /// <summary>
        /// display results from the nth result
        /// </summary>
        uint offset { get; set; }

        /// <summary>
        /// return no more than value results
        /// </summary>
        uint count { get; set; }

        /// <summary>
        /// match case if value is nonzero
        /// </summary>
        uint @case { get; set; }

        /// <summary>
        /// search whole words if value is nonzero
        /// </summary>
        uint wholeword { get; set; }

        /// <summary>
        /// search whole paths if value is nonzero
        /// </summary>
        uint path { get; set; }

        /// <summary>
        /// perform a regex search if value is nonzero
        /// </summary>
        uint regex { get; set; }

        /// <summary>
        /// match diacritics if value is nonzero
        /// </summary>
        uint diacritics { get; set; }

        /// <summary>
        /// list the result's path in the json object if value is nonzero
        /// </summary>
        uint path_column { get; set; }

        /// <summary>
        /// list the result's size in the json object if value is nonzero
        /// </summary>
        uint size_column { get; set; }

        /// <summary>
        /// list the result's modified date in the json object if value is nonzero
        /// </summary>
        uint date_modified_column { get; set; }

        /// <summary>
        /// list the result's creation date in the json object if value is nonzero
        /// </summary>
        uint date_created_column { get; set; }

        /// <summary>
        /// list the result's attributes in the json object if value is nonzero
        /// </summary>
        uint attributes_column { get; set; }
    }
}
