using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using DSServicesGateway.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DSServicesGateway.Authentication
{
    public class SSOAuthHandler : AuthenticationHandler<CustomAuthOptions>
    {
        public const string AuthenticationScheme = "SSO Scheme";
//        private readonly ISSOAuthenticationService _authenticationService;

        public SSOAuthHandler(IOptionsMonitor<CustomAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
            // store custom services here...
            long k = 9;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authenticationService = Context.RequestServices.GetService(typeof(ISSOAuthenticationService)) as ISSOAuthenticationService;
            if (null == authenticationService)
            {
                return AuthenticateResult.Fail("Authentication service not registered");
            }

            var token = Context.Request.Headers["x-session"].FirstOrDefault();
            if (string.IsNullOrWhiteSpace(token))
            {
                return AuthenticateResult.Fail("token not found");
            }

            var claimsIdentity = await authenticationService.AuthenticateTokenAsync(token);
            if(null != claimsIdentity)
            {
                Context.User = new ClaimsPrincipal(claimsIdentity);
                return AuthenticateResult.Success(new AuthenticationTicket(Context.User, AuthenticationScheme));
            }

            return AuthenticateResult.NoResult();
        }
    }
}