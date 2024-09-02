using HrApp.Interfaces.Services;
using HrApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmanController : ControllerBase
    {
        private readonly IDepartmanService _DepartmanService;

        public DepartmanController(IDepartmanService DepartmanService)
        {
            _DepartmanService = DepartmanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartmans()
        {
            var Departmans = await _DepartmanService.GetAllDepartmansAsync();
            return Ok(Departmans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartman(int id)
        {
            var Departman = await _DepartmanService.GetDepartmanByIdAsync(id);
            if (Departman == null)
            {
                return NotFound();
            }
            return Ok(Departman);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartman(DepartmanModel Departman)
        {
            var createdDepartman = await _DepartmanService.CreateDepartmanAsync(Departman);
            return CreatedAtAction(nameof(GetDepartman), new { id = createdDepartman.DepartmantId }, createdDepartman);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartman(int id, DepartmanModel Departman)
        {
            if (id != Departman.DepartmantId)
            {
                return BadRequest();
            }

            var success = await _DepartmanService.UpdateDepartmanAsync(Departman);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartman(int id)
        {
            var success = await _DepartmanService.DeleteDepartmanAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
