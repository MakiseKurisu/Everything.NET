using System;
using System.ComponentModel;

namespace Everything.NET.Library
{
    /// <summary>
    /// Basic query result
    /// </summary>
    public class RawResult
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

    /// <summary>
    /// Json return object
    /// </summary>
    public class RawResults
    {
        public RawResult[] results;
    }
}