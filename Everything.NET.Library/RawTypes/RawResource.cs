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
        /// Path of the object
        /// </summary>
        public string path;

        /// <summary>
        /// Size of the object
        /// </summary>
        public string size;

        /// <summary>
        /// Object's modified date
        /// </summary>
        public string date_modified;

        /// <summary>
        /// Object's created date
        /// </summary>
        public string date_created;

        /// <summary>
        /// Object's attributes
        /// </summary>
        public string attributes;
    }
}