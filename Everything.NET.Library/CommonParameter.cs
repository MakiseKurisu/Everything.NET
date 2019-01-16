using CommandLine;

namespace Everything.NET.Library
{
    public class CommonParameter
    {
        [Option('w', "width", Default = 20, HelpText = "Set column size.", Hidden = false, Required = false)]
        public int _Width { get; set; }
    }
}
