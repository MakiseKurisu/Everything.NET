using CommandLine;
using CommandLine.Text;
using Everything.NET.Library;
using System.Collections.Generic;

namespace Everything.NET.Verbs
{
    [Verb("size", HelpText = "Return size of a given target.")]
    public class SizeVerb: CommonOption, IVerbBase
    {
        [Usage]
        public static IEnumerable<Example> Examples
        {
            get => new List<Example>() {
                new Example("Return size of a given target.", new CommonOption { uri = @"http://www.example.com:8080/C:"})
            };
        }

        public int Action()
        {
            using (var req = new Request(uri))
            {
                req.LocateParent();

                return 0;
            }
        }
    }
}