
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.ApplicationCore.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService=userService;
        }


        public IActionResult Register()
        {
            var newRegister = new RegisterDto();
            return View(newRegister);
        }

        [HttpPost("registerUser")]
        public async Task<ResponseStatus> RegisterUser([FromBody] RegisterDto dto)
        {
            return await _userService.RegisterUser(dto.UserName,dto.Password, dto.Email);
        }

        [HttpPost("loginAccaunt")]
        public async Task<TokenDto> LoginUser([FromBody] LoginDto dto)
        {
            return await _userService.LoginUser(dto.UserName, dto.Password);
        }

        [HttpGet("getProfile/{id}"), Authorize(AuthenticationSchemes = "Bearer ",Roles ="Admin")]
        public async Task<Profile> GetProfile([FromRoute] int id)
        {
            return await _userService.GetProfile(id);
        }

    }
}
