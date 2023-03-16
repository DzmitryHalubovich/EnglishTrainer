using JWTTokensTest.Common;

namespace EnglishTrainer.Web.Configuration
{
    public static class AppExstentions
    {
        public static IApplicationBuilder UseSecureJwt(this IApplicationBuilder builder) => builder.UseMiddleware<AuthorizationMiddleware>();

    }
}
