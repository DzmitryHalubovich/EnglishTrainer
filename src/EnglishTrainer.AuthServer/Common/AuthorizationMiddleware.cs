using JWTTokensTest.Config;
using Microsoft.Extensions.Options;

namespace JWTTokensTest.Common
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AuthorizationConfig _authorizationConfig;

        public AuthorizationMiddleware(RequestDelegate next,
        IOptions<AuthorizationConfig> authorizationConfig)
        {
            _next = next;
            _authorizationConfig = authorizationConfig.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var RoleClaim = context.User.Claims?.First(x =>
                x.Type.Equals(_authorizationConfig.MicrosoftClaimsGateway,
                StringComparison.InvariantCultureIgnoreCase)).Value.ToString();

                if (RoleClaim != null)
                {
                    context.Response.Headers["X-UserRole"] = RoleClaim;
                }
            }
            catch (Exception ex)
            {

            }
            await _next.Invoke(context);
        }
    }
}

