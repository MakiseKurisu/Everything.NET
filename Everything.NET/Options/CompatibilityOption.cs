using System.Threading.Tasks;
using CommandLine;
using Everything.NET.Library;
using Everything.NET.Verbs;

namespace Everything.NET.Options
{
    public class CompatibilityOption : IVerbBase
    {
        [Option("no_mime_type_check", Default = false, HelpText = "Disable MIME type check. Useful when detecting bad response early, but not supported in older Everything.", Hidden = false, Required = false)]
        public bool no_mime_type_check { get; set; }

        public virtual Task<int> Action()
        {
            throw new System.NotImplementedException();
        }

        public virtual IVerbBase SetLibraryOption()
        {
            Option.no_mime_type_check = no_mime_type_check;
            return this;
        }
    }
}
