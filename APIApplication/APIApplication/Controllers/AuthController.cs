using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using APIApplication.Entities;
using APIApplication.Services.Interfaces;
using APIApplication.Models.Request;
using APIApplication.Models.Respone;

namespace APIApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] LoginRequest request)
        {
            var user = await authService.RegiserAsync(request);
            if (user is null)
                return BadRequest("User already exsited.");

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenRespone>> Login(LoginRequest request)
        {

            var result = await authService.LoginAsync(request);
            if(result is null)
                return BadRequest("Wrong username or password");

            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenRespone>> RefreshToken(RefreshTokenRespone refreshTokenDto)
        {
            var result = await authService.RefreshTokensAsync(refreshTokenDto);
            if(result is null || result.AccessToken is null || result.RefreshToken is null)
            {
                return Unauthorized("Invalid refresh token.");
            }

            return Ok(result);
        }

    }
}
