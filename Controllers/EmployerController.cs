using HrApp.Interfaces.Services;
using HrApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerService _EmployerService;

        public EmployerController(IEmployerService EmployerService)
        {
            _EmployerService = EmployerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployers()
        {
            var Employers = await _EmployerService.GetAllEmployersAsync();
            return Ok(Employers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployer(int id)
        {
            var Employer = await _EmployerService.GetEmployerByIdAsync(id);
            if (Employer == null)
            {
                return NotFound();
            }
            return Ok(Employer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployer(EmployerModel Employer)
        {
            var createdEmployer = await _EmployerService.CreateEmployerAsync(Employer);
            return CreatedAtAction(nameof(GetEmployer), new { id = createdEmployer.EmployeeId }, createdEmployer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployer(int id, EmployerModel Employer)
        {
            if (id != Employer.EmployeeId)
            {
                return BadRequest();
            }

            var success = await _EmployerService.UpdateEmployerAsync(Employer);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployer(int id)
        {
            var success = await _EmployerService.DeleteEmployerAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
