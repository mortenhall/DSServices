using Microsoft.AspNetCore.Mvc;
using SubscriptionServices.Model.Client;

namespace SubscriptionServices.Controllers
{
    [ApiController]
    [Route("Subscription")]
    public class SubscriptionController : ControllerBase
    {
        [HttpGet]
        [Route("{id}/info")]
        public ActionResult<SubscriptionInfoResponse> GetSubscriptionInfo(string id)
        {
            var response = new SubscriptionInfoResponse
            {
                Id = id
            };

            return response;
        }

    }
}