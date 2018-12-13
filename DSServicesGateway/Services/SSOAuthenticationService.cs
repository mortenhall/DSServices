using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DSServicesGateway.Services
{
    public class SSOAuthenticationService : ISSOAuthenticationService
    {
        public async Task<ClaimsIdentity> AuthenticateTokenAsync(string token)
        {
            // call SSO service

            // Dummy code
            if (string.IsNullOrWhiteSpace(token) || token != "12345")
                return null;

            var claims = new List<Claim>
            {
                new Claim("PlayerId", "42"),
                new Claim(ClaimTypes.Name, "SSO User"),
                new Claim("DSContext", "DLO"),
                new Claim(ClaimTypes.NameIdentifier, "MyUserID"),
                new Claim(ClaimTypes.Role, "MyRole")
            };

            var claimsIdentity = new ClaimsIdentity(claims, "SSO");
            return claimsIdentity;
        }
    }
}