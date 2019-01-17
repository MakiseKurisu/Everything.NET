using System;

namespace Everything.NET.Library.Extensions
{
    public static class UriExtensions
    {
        public static Uri LocateParent(this Uri uri)
        {
            return LocateChild(uri, "..");
        }

        public static Uri LocateChild(this Uri uri, string child)
        {
            return new Uri(uri, child);
        }
    }
}
