using System.Security.Claims;

namespace JWTTokensTest.Interfaces
{
    public interface ITokenService
    {
        public string GenerateAccessToken(IEnumerable<Claim> claims);
    }
}
