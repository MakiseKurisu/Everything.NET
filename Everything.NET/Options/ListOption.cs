using CommandLine;
using Everything.NET.Library.RawTypes.Queries;

namespace Everything.NET.Options
{
    public class ListOption: CommonOption, RawBaseQuery
    {
        [Option('j', "json", Default = 1u, HelpText = "Return results as a JSON object if value is nonzero.", Hidden = true, Required = false)]
        public uint json { get; set; }

        [Option("sort", Default = "name", HelpText = "Where value can be one of the following: name, path, date_modified, or size.", Hidden = false, Required = false)]
        public string sort { get; set; }

        [Option("ascending", Default = 1u, HelpText = "Sort by ascending order if value is nonzero.", Hidden = false, Required = false)]
        public uint ascending { get; set; }
    }
}
