using System;
using Microsoft.AspNetCore.Authentication;

namespace DSServicesGateway.Authentication
{
    public static class CustomAuthExtensions
    {
        public static AuthenticationBuilder AddSSOAuth(this AuthenticationBuilder builder,
            Action<CustomAuthOptions> configureOptions)
        {
            return builder.AddScheme<CustomAuthOptions, SSOAuthHandler>(SSOAuthHandler.AuthenticationScheme, "SSO Authentication", configureOptions);
        }
    }
}