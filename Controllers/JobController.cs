using HrApp.Interfaces.Services;
using HrApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _JobService;

        public JobController(IJobService JobService)
        {
            _JobService = JobService;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var Jobs = await _JobService.GetAllJobsAsync();
            return Ok(Jobs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob(int id)
        {
            var Job = await _JobService.GetJobByIdAsync(id);
            if (Job == null)
            {
                return NotFound();
            }
            return Ok(Job);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob(JobModel Job)
        {
            var createdJob = await _JobService.CreateJobAsync(Job);
            return CreatedAtAction(nameof(GetJob), new { id = createdJob.JobId }, createdJob);
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
