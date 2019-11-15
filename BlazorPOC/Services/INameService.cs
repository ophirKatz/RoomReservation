using System.Threading.Tasks;

namespace BlazorPOC.Services
{
    public interface INameService
    {
        Task<string> GetNameAsync();
    }
}