using HrApp.Dtos.Requests;
using HrApp.Interfaces.ApplicationServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CacheController : ControllerBase
    {
        private readonly IRedisCacheService _redisCacheService;

        public CacheController(IRedisCacheService redisCacheService)
        {
            _redisCacheService = redisCacheService;
        }

        [HttpGet("cache/{key}")]
        public async Task<IActionResult> Get(string key)
        {
            return Ok(await _redisCacheService.GetValueAsync(key));
        }

        [HttpPost("set")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Set([FromBody] RedisCacheRequest redisCacheRequest)
        {
            await _redisCacheService.SetValueAsync(redisCacheRequest.Key, redisCacheRequest.Value);
            return Ok();
        }

        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            await _redisCacheService.Clear(key);
            return Ok();
        }


    }
}
