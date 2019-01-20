using CommandLine;
using Everything.NET.Library.RawTypes.Queries;

namespace Everything.NET.Options
{
    public class SearchOption: ListOption, RawSearchQuery
    {
        [Option('s', "search", Default = "", HelpText = "Search text.", Hidden = false, Required = false)]
        public string search { get; set; }

        [Option('o', "offset", Default = 0u, HelpText = "Display results from the nth result.", Hidden = false, Required = false)]
        public uint offset { get; set; }

        [Option('c', "count", Default = 4294967295u, HelpText = "Return no more than value results.", Hidden = false, Required = false)]
        public uint count { get; set; }

        [Option('i', "case", Default = 0u, HelpText = "Match case if value is nonzero.", Hidden = false, Required = false)]
        public uint @case { get; set; }

        [Option('w', "wholeword", Default = 0u, HelpText = "Search whole words if value is nonzero.", Hidden = false, Required = false)]
        public uint wholeword { get; set; }

        [Option('p', "path", Default = 0u, HelpText = "Search whole paths if value is nonzero.", Hidden = false, Required = false)]
        public uint path { get; set; }

        [Option('r', "regex", Default = 0u, HelpText = "Perform a regex search if value is nonzero.", Hidden = false, Required = false)]
        public uint regex { get; set; }

        [Option('m', "diacritics", Default = 0u, HelpText = "Match diacritics if value is nonzero.", Hidden = false, Required = false)]
        public uint diacritics { get; set; }

        [Option("path_column", Default = 0u, HelpText = "List the result's path in the json object if value is nonzero.", Hidden = false, Required = false)]
        public uint path_column { get; set; }

        [Option("size_column", Default = 0u, HelpText = "List the result's size in the json object if value is nonzero.", Hidden = false, Required = false)]
        public uint size_column { get; set; }

        [Option("date_modified_column", Default = 0u, HelpText = "List the result's modified date in the json object if value is nonzero.", Hidden = false, Required = false)]
        public uint date_modified_column { get; set; }

        [Option("date_created_column", Default = 0u, HelpText = "List the result's creation date in the json object if value is nonzero.", Hidden = false, Required = false)]
        public uint date_created_column { get; set; }

        [Option("attributes_column", Default = 0u, HelpText = "List the result's attributes in the json object if value is nonzero.", Hidden = false, Required = false)]
        public uint attributes_column { get; set; }
    }
}
