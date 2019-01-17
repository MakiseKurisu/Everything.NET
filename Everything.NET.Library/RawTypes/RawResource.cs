namespace Everything.NET.Library.RawTypes
{
    /// <summary>
    /// Basic query result
    /// </summary>
    public class RawResource
    {
        /// <summary>
        /// Type of object, as in ResultType
        /// </summary>
        public string type;

        /// <summary>
        /// Name of the object
        /// </summary>
        public string name;

        /// <summary>
        /// Size of the object
        /// </summary>
        public string size;

        /// <summary>
        /// Object's modified date
        /// </summary>
        public string date_modified;
    }
}