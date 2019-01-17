namespace Everything.NET.Library.Types
{
    public class FileSize
    {
        public ulong Count { get; set; }

        public ulong Raw { get; set; }

        public FileSize(ulong s)
        {
            Count = 1;
            Raw = s;
        }

        public FileSize() : this(0ul) { }

        public FileSize(long s)
        {
            Raw = (ulong) (s > 0 ? s : -s);
        }

        /// <summary>
        /// https://stackoverflow.com/questions/281640/how-do-i-get-a-human-readable-file-size-in-bytes-abbreviation-using-net
        /// Returns the human-readable file size for an arbitrary, 64-bit file size 
        /// The default format is "0.### XB", e.g. "4.2 KB" or "1.434 GB"
        /// </summary>
        public override string ToString()
        {
            // Determine the suffix and readable value
            string suffix;
            double readable;
            if (Raw >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = (Raw >> 50);
            }
            else if (Raw >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = (Raw >> 40);
            }
            else if (Raw >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = (Raw >> 30);
            }
            else if (Raw >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = (Raw >> 20);
            }
            else if (Raw >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = (Raw >> 10);
            }
            else if (Raw >= 0x400) // Kilobyte
            {
                suffix = "KB";
                readable = Raw;
            }
            else
            {
                return Raw.ToString("0 B"); // Byte
            }

            // Divide by 1024 to get fractional value
            readable = (readable / 1024);
            // Return formatted number with suffix
            return readable.ToString("0.### ") + suffix;
        }

        public static FileSize operator +(FileSize b, FileSize c)
        {
            var a = new FileSize(b.Raw + c.Raw)
            {
                Count = b.Count + c.Count
            };
            return a;
        }

        public static FileSize operator -(FileSize b, FileSize c)
        {
            var a = new FileSize(b.Raw - c.Raw)
            {
                Count = b.Count - c.Count
            };
            return a;
        }
    }
}
