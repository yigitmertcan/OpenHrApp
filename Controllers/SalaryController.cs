using HrApp.Interfaces.Services;
using HrApp.Models;
using HrApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _SalaryService;

        public SalaryController(ISalaryService SalaryService)
        {
            _SalaryService = SalaryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSalarys()
        {
            var Salarys = await _SalaryService.GetAllSalarysAsync();
            return Ok(Salarys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalary(int id)
        {
            var Salary = await _SalaryService.GetSalaryByIdAsync(id);
            if (Salary == null)
            {
                return NotFound();
            }
            return Ok(Salary);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSalary(SalaryModel Salary)
        {
            var createdSalary = await _SalaryService.CreateSalaryAsync(Salary);
            return CreatedAtAction(nameof(GetSalary), new { id = createdSalary.SalaryId }, createdSalary);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalary(int id, SalaryModel Salary)
        {
            if (id != Salary.SalaryId)
            {
                return BadRequest();
            }

            var success = await _SalaryService.UpdateSalaryAsync(Salary);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalary(int id)
        {
            var success = await _SalaryService.DeleteSalaryAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
