using System.Security.Claims;
using System.Security.Principal;

namespace DSServicesGateway.Authentication
{
    public class UserIdentity : ClaimsPrincipal
    {
        public UserIdentity() : base()
        {
            
        }

        public override IIdentity Identity { get
            {
                return new ClaimsIdentity()
                {
                };
            }
        }
        //public override bool IsAuthenticated => true;
    }
}