using BCrypt.Net;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.Infrastructure.Data;
using EnglishTrainer.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace EnglishTrainer.Services
{
    public class UserService : IUserService
    {
        private readonly EnglishTrainerContext _efContex;
        private readonly ITokenService _tokenService;

        public UserService(ITokenService tokenService, EnglishTrainerContext efContex)
        {
            _tokenService=tokenService;
            _efContex=efContex;
        }

        public async Task<Profile> GetProfile(int id)
        {
            return await _efContex.Profiles.Include(x=>x.User).FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<TokenDto> LoginUser(string userName, string password)
        {
            var user = await _efContex.Users.FirstOrDefaultAsync(x=>x.Username == userName);

            if (user == null)
            {
                throw new Exception("Invalid name or password");
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new Exception("Invalid credentials");
            }

            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var accessToken =  _tokenService.GenerateAccessToken(claims);

            return new TokenDto { AccessToken= accessToken };

        }

        public async Task<ResponseStatus> RegisterUser(string userName, string password, string email)
        {

            User user = new User
            {
                Email= email,
                Username= userName,
                Password= BCrypt.Net.BCrypt.HashPassword(password),
                Role = "user",
            };

            Profile profile = new Profile
            {
                Name= userName,
                Email= email,
                User = user,
            };

            var duplicateUser = await _efContex.Users.FirstOrDefaultAsync(x=>x.Username == userName);
            var duplicateEmail = await _efContex.Users.FirstOrDefaultAsync(x =>x.Email==email);

            if (duplicateUser == null && duplicateEmail == null)
            {
                await _efContex.Users.AddAsync(user);
                await _efContex.Profiles.AddAsync(profile);
                await _efContex.SaveChangesAsync();

                return new ResponseStatus { Status = "Success account created" };
            }
            else
            {
                return new ResponseStatus { Status = "Sorry, this account exists" };
            }
        }
    }
}
