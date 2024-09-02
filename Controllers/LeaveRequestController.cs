using HrApp.Interfaces.Services;
using HrApp.Models;
using HrApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestService _LeaveRequestService;

        public LeaveRequestController(ILeaveRequestService LeaveRequestService)
        {
            _LeaveRequestService = LeaveRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeaveRequests()
        {
            var LeaveRequests = await _LeaveRequestService.GetAllLeaveRequestsAsync();
            return Ok(LeaveRequests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeaveRequest(int id)
        {
            var LeaveRequest = await _LeaveRequestService.GetLeaveRequestByIdAsync(id);
            if (LeaveRequest == null)
            {
                return NotFound();
            }
            return Ok(LeaveRequest);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeaveRequest(LeaveRequestModel LeaveRequest)
        {
            var createdLeaveRequest = await _LeaveRequestService.CreateLeaveRequestAsync(LeaveRequest);
            return CreatedAtAction(nameof(GetLeaveRequest), new { id = createdLeaveRequest.LeaveRequestId }, createdLeaveRequest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeaveRequest(int id, LeaveRequestModel LeaveRequest)
        {
            if (id != LeaveRequest.LeaveRequestId)
            {
                return BadRequest();
            }

            var success = await _LeaveRequestService.UpdateLeaveRequestAsync(LeaveRequest);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveRequest(int id)
        {
            var success = await _LeaveRequestService.DeleteLeaveRequestAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
