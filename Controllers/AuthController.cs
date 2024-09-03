using Hangfire;
using HrApp.Dtos.Requests;
using HrApp.Dtos.Responses;
using HrApp.Interfaces.Services;
using HrApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("LoginUser")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLoginResponse>> LoginUserAsync([FromBody] UserLoginRequest request)
        {
            var result = await authService.LoginUserAsync(request);

            return result;
        }

        [HttpGet("UserInfo")]
        [Authorize]
        //[Authorize(Roles = "User")]
        public async Task<ActionResult<UserModel>> GetUserInfoAsync()
        {
            return Ok();
        }

        [HttpPost("ChangeUserInfo")]
        [Authorize]
        public async Task<ActionResult<UserLoginResponse>> ChangeUserInfoAsync([FromBody] UserLoginRequest request)
        {
            var result = await authService.LoginUserAsync(request);

            return result;
        }

        [HttpPost("ChangePassword")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLoginResponse>> ChangePasswordAsync([FromBody] UserLoginRequest request)
        {
            var result = await authService.LoginUserAsync(request);

            return result;
        }
    }
}
