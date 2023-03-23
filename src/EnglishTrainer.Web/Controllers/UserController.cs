﻿
using Azure;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.ApplicationCore.Response;
using EnglishTrainer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

            if (ModelState.IsValid)
            {
                var response = await _userService.RegisterUser(dto.UserName, dto.Password, dto.Email);

                if (response.StatusCode == Enums.StatusCode.UserIsHasAlready)
                {
                    return BadRequest(new { description = response.Description });
                }

                var token = await _userService.LoginUser(dto.UserName, dto.Password);

                HttpContext.Response.Cookies.Append("X-UserRole", token.AccessToken);

                //return RedirectToAction("MainTable", "Verb");

                return Ok(new { description = response.Description });
            }
            else
            {
                return View();
            }

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

            //HttpContext.Request.Headers.Add("Authorization", "Bearer"+ token.AccessToken.ToString());
            //Response.Cookies.Append("Bearer", token.AccessToken);
            HttpContext.Response.Cookies.Append("X-UserRole", token.AccessToken);
            return RedirectToAction("Index", "Verb");

            //return await _userService.LoginUser(dto.UserName, dto.Password);
        }

        [HttpGet("getProfile/{id}"), Authorize(AuthenticationSchemes = "Bearer ",Roles ="user")]
        public async Task<Profile> GetProfile([FromRoute] int id)
        {
            return await _userService.GetProfile(id);
        }

    }
}
