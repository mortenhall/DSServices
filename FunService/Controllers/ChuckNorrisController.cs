using System.Threading.Tasks;
using FunService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FunService.Controllers
{
    [ApiController]
    [Route("chucknorris")]
    public class ChuckNorrisController
    {
        private IChuckNorrisService _chuckNorrisService;

        public ChuckNorrisController(IChuckNorrisService chuckNorrisService)
        {
            _chuckNorrisService = chuckNorrisService;
        }

        [HttpGet]
        [Route("jokes/random")]
        public async Task<ActionResult<string>> GetRandomJoke()
        {
            var joke = await _chuckNorrisService.GetRandomJokeAsync();

            return joke;
        }
    }
}