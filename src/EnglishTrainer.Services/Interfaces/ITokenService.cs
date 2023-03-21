using System.Security.Claims;

namespace EnglishTrainer.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateAccessToken(IEnumerable<Claim> claims);
    }
}
