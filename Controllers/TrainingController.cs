using HrApp.Interfaces.Services;
using HrApp.Models;
using HrApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _TrainingService;

        public TrainingController(ITrainingService TrainingService)
        {
            _TrainingService = TrainingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrainings()
        {
            var Trainings = await _TrainingService.GetAllTrainingsAsync();
            return Ok(Trainings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTraining(int id)
        {
            var Training = await _TrainingService.GetTrainingByIdAsync(id);
            if (Training == null)
            {
                return NotFound();
            }
            return Ok(Training);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTraining(TrainingModel Training)
        {
            var createdTraining = await _TrainingService.CreateTrainingAsync(Training);
            return CreatedAtAction(nameof(GetTraining), new { id = createdTraining.TrainingId }, createdTraining);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTraining(int id, TrainingModel Training)
        {
            if (id != Training.TrainingId)
            {
                return BadRequest();
            }

            var success = await _TrainingService.UpdateTrainingAsync(Training);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraining(int id)
        {
            var success = await _TrainingService.DeleteTrainingAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
