using CommandLine;

namespace Everything.NET.Options
{
    public class CompatibilityOption
    {
        [Option("no_mime_type_check", Default = false, HelpText = "Disable MIME type check. Useful when detecting bad response early, but not supported in older Everything.", Hidden = false, Required = false)]
        public bool no_mime_type_check { get; set; }
    }
}
