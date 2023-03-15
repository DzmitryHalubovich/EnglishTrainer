using JWTTokensTest.Dto;
using JWTTokensTest.Dto.ResponseDto;
using JWTTokensTest.Entities;
using JWTTokensTest.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTTokensTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService=userService;
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
