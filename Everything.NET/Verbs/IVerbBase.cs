using System.Threading.Tasks;

namespace Everything.NET.Verbs
{
    public interface IVerbBase
    {
        Task<int> Action();
    }
}
