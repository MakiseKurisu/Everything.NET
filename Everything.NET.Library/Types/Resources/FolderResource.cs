using Everything.NET.Library.RawTypes;

namespace Everything.NET.Library.Types.Resources
{
    public class FolderResource: BaseResource
    {
        public override FileSize Size { get; set; }

        public FolderResource(RawResource obj) : base(obj) { }
    }
}
