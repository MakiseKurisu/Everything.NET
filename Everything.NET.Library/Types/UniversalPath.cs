namespace Everything.NET.Library.Types
{
    public class UniversalPath
    {
        private string Path;
        public UniversalPath(string p)
        {
            Path = RemoveLeadingSlash(ConvertToUriPath(p));
        }

        public string RemoveLeadingSlash(string str)
        {
            while (str.IndexOf('/') == 0)
            {
                str = str.Substring(1);
            }
            return str;
        }

        public string UriPath => ConvertToUriPath(Path);
        public string WindowsPath => ConvertToWindowsPath(Path);
        public string WindowsSubfolderPath => ConvertToWindowsSubfolderPath(Path);

        public string ConvertToUriPath(string str)
        {
            return str.Replace('\\', '/');
        }

        public string ConvertToWindowsPath(string str)
        {
            return str.Replace('/', '\\');
        }

        public string ConvertToWindowsSubfolderPath(string str)
        {
            return ConvertToWindowsPath(str).Replace(":", string.Empty);
        }
    }
}
