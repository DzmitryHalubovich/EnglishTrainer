
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Models;

namespace EnglishTrainer.Services.Interfaces
{
    public interface IUserService
    {
        public Task<ResponseStatus> RegisterUser(string userName, string password, string email);

        public Task<TokenDto> LoginUser(string userName, string password);

        public Task<Profile> GetProfile(int id);

    }
}
