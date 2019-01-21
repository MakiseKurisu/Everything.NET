using System.Threading.Tasks;

namespace Everything.NET.Verbs
{
    public interface IVerbBase
    {
        Task<int> Output();
        Task<object> Fetch();
        Task<int> Display(Task<object> obj);
        IVerbBase SetLibraryOption();
    }
}
