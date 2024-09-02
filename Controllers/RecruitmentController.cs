using HrApp.Dtos.Requests;
using HrApp.Interfaces.Services;
using HrApp.Models;
using HrApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentController : ControllerBase
    {
        private readonly IRecruitmentService _RecruitmentService;

        public RecruitmentController(IRecruitmentService RecruitmentService)
        {
            _RecruitmentService = RecruitmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecruitments()
        {
            var Recruitments = await _RecruitmentService.GetAllRecruitmentsAsync();
            return Ok(Recruitments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecruitment(int id)
        {
            var Recruitment = await _RecruitmentService.GetRecruitmentByIdAsync(id);
            if (Recruitment == null)
            {
                return NotFound();
            }
            return Ok(Recruitment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecruitment(RecruitmentRequest Recruitment)
        {
            var createdRecruitment = await _RecruitmentService.CreateRecruitmentAsync(Recruitment);
            return CreatedAtAction(nameof(GetRecruitment), new { id = createdRecruitment.RecruitmentId }, createdRecruitment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecruitment(int id, RecruitmentModel Recruitment)
        {
            if (id != Recruitment.RecruitmentId)
            {
                return BadRequest();
            }

            var success = await _RecruitmentService.UpdateRecruitmentAsync(Recruitment);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecruitment(int id)
        {
            var success = await _RecruitmentService.DeleteRecruitmentAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
