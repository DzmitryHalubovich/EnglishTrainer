
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.ApplicationCore.Response;

namespace EnglishTrainer.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IBaseResponse<User>> RegisterUser(string userName, string password, string email);

        public Task<TokenDto> LoginUser(string userName, string password);

        public Task<Profile> GetProfile(int id);

    }
}
