using HrApp.Interfaces.Services;
using HrApp.Models;
using HrApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var Users = await _UserService.GetAllUsersAsync();
            return Ok(Users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var User = await _UserService.GetUserByIdAsync(id);
            if (User == null)
            {
                return NotFound();
            }
            return Ok(User);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel User)
        {
            var createdUser = await _UserService.CreateUserAsync(User);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserModel User)
        {
            if (id != User.Id)
            {
                return BadRequest();
            }

            var success = await _UserService.UpdateUserAsync(User);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _UserService.DeleteUserAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
