using System;
using System.ComponentModel;

namespace Everything.NET.Library
{
    /// <summary>
    /// Basic query result
    /// </summary>
    public class Result
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

    public enum ResultType
    {
        /// <summary>
        /// Object is a file.
        /// </summary>
        [Description("file")]
        File,

        /// <summary>
        /// Object is a folder.
        /// </summary>
        [Description("folder")]
        Folder,
    }

    public static class ResultTypeExtensions
    {
        public static T ToEnum<T>(this string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T) field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T) field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
        }
    }

    /// <summary>
    /// Json return object
    /// </summary>
    public class Results
    {
        public Result[] results;
    }
}