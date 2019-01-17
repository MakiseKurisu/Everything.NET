namespace Everything.NET.Library.RawTypes.Queries
{
    /// <summary>
    /// Define parameters used in Request
    /// See https://www.voidtools.com/support/everything/http/ for definition and default value
    /// </summary>
    public class RawBaseQuery
    {
        /// <summary>
        /// Return results as a JSON object if value is nonzero.
        /// </summary>
        public uint json;

        /// <summary>
        /// Where value can be one of the following: name, path, date_modified, or size.
        /// </summary>
        public string sort;

        /// <summary>
        /// Sort by ascending order if value is nonzero.
        /// </summary>
        public uint ascending;

        public RawBaseQuery()
        {
            json = 1;
            sort = "name";
            ascending = 1;
        }

        public override string ToString()
        {
            return $"json={json}&sort={sort}&ascending={ascending}";
        }
    }
}
