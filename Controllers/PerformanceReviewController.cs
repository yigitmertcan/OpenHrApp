using HrApp.Dtos.Requests;
using HrApp.Interfaces.Services;
using HrApp.Models;
using HrApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceReviewController : ControllerBase
    {
        private readonly IPerformanceReviewService _PerformanceReviewService;

        public PerformanceReviewController(IPerformanceReviewService PerformanceReviewService)
        {
            _PerformanceReviewService = PerformanceReviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPerformanceReviews()
        {
            var PerformanceReviews = await _PerformanceReviewService.GetAllPerformanceReviewsAsync();
            return Ok(PerformanceReviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerformanceReview(int id)
        {
            var PerformanceReview = await _PerformanceReviewService.GetPerformanceReviewByIdAsync(id);
            if (PerformanceReview == null)
            {
                return NotFound();
            }
            return Ok(PerformanceReview);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerformanceReview(PerformanceReviewRequest PerformanceReview)
        {
            var createdPerformanceReview = await _PerformanceReviewService.CreatePerformanceReviewAsync(PerformanceReview);
            return CreatedAtAction(nameof(GetPerformanceReview), new { id = createdPerformanceReview.ReviewId }, createdPerformanceReview);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerformanceReview(int id, PerformanceReviewModel PerformanceReview)
        {
            if (id != PerformanceReview.ReviewId)
            {
                return BadRequest();
            }

            var success = await _PerformanceReviewService.UpdatePerformanceReviewAsync(PerformanceReview);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerformanceReview(int id)
        {
            var success = await _PerformanceReviewService.DeletePerformanceReviewAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
