using JWTTokensTest.Dto;
using JWTTokensTest.Dto.ResponseDto;
using JWTTokensTest.Entities;

namespace JWTTokensTest.Interfaces
{
    public interface IUserService
    {
        public Task<ResponseStatus> RegisterUser(string userName, string password, string email);

        public Task<TokenDto> LoginUser(string userName, string password);

        public Task<Profile> GetProfile(int id);

    }
}
