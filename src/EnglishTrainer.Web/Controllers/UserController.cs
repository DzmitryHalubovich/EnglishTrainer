
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

        [HttpGet]
        public IActionResult Register()
        {
            var newRegister = new RegisterDto();
            return View(newRegister);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterDto dto)
        {
            await _userService.RegisterUser(dto.UserName,dto.Password, dto.Email);

            return RedirectToAction("Main", "Verb");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var newLogin = new LoginDto();
            return View(newLogin);
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginDto dto)
        {
            var token = await _userService.LoginUser(dto.UserName, dto.Password);

            HttpContext.Request.Headers.Add("Authorization", "Bearer"+ token.AccessToken.ToString());

            return RedirectToAction("Index", "Verb");

            //return await _userService.LoginUser(dto.UserName, dto.Password);
        }

        [HttpGet("getProfile/{id}"), Authorize(AuthenticationSchemes = "Bearer ",Roles ="Admin")]
        public async Task<Profile> GetProfile([FromRoute] int id)
        {
            return await _userService.GetProfile(id);
        }

    }
}
