using Everything.NET.Library.Actions;
using Everything.NET.Library.RawTypes;

namespace Everything.NET.Library.Types.Resources
{
    public class FolderResource: BaseResource
    {
        public override FileSize Size
        {
            get
            {
                var contents = ListAction.Action(Uri, new Queries.BaseQuery());
                var size = new FileSize();
                foreach (var c in contents)
                {
                    size += c.Size;
                }
                return size;
            }
            set { }
        }

        public FolderResource(RawResource obj) : base(obj) { }
    }
}
