namespace Everything.NET.Library.RawTypes.Queries
{
    /// <summary>
    /// Define parameters used in Request
    /// See https://www.voidtools.com/support/everything/http/ for definition and default value
    /// </summary>
    public interface RawBaseQuery
    {
        /// <summary>
        /// Return results as a JSON object if value is nonzero.
        /// </summary>
        uint json { get; set; }

        /// <summary>
        /// Where value can be one of the following: name, path, date_modified, or size.
        /// </summary>
        string sort { get; set; }

        /// <summary>
        /// Sort by ascending order if value is nonzero.
        /// </summary>
        uint ascending { get; set; }
    }
}
