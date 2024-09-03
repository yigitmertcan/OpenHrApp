using HrApp.Dtos.Requests;
using HrApp.Interfaces.Services;
using HrApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _JobService;

        public JobsController(IJobService JobService)
        {
            _JobService = JobService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob(JobRequest Job)
        {
            var createdJob = await _JobService.CreateJobAsync(Job);
            return Ok(createdJob);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, JobModel Job)
        {
            if (id != Job.JobId)
            {
                return BadRequest();
            }

            var success = await _JobService.UpdateJobAsync(Job);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var success = await _JobService.DeleteJobAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
