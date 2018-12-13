using Microsoft.AspNetCore.Mvc;
using NumberGamesProvider.Model.Client;

namespace NumberGamesProvider.Controllers
{
    [Route("lotto")]
    [ApiController]
    public class LottoController : ControllerBase
    {
        [HttpGet]
        [Route("gameinformation")]
        public ActionResult<LottoGameInformationResponse> GetGameInformation()
        {
            var response = new LottoGameInformationResponse
            {
                Name = "Lotto"
            };

            return response;
        }
    }
}