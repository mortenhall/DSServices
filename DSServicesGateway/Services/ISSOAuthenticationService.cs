using System.Security.Claims;
using System.Threading.Tasks;

namespace DSServicesGateway.Services
{
    public interface ISSOAuthenticationService
    {
        Task<ClaimsIdentity> AuthenticateTokenAsync(string token);
    }
}