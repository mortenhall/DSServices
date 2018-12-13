using System.Threading.Tasks;

namespace FunService.Services
{
    public interface IChuckNorrisService
    {
        Task<string> GetRandomJokeAsync();
    }
}