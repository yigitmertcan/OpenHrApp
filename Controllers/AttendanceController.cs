using HrApp.Interfaces.Services;
using HrApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _AttendanceService;

        public AttendanceController(IAttendanceService AttendanceService)
        {
            _AttendanceService = AttendanceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAttendances()
        {
            var Attendances = await _AttendanceService.GetAllAttendancesAsync();
            return Ok(Attendances);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendance(int id)
        {
            var Attendance = await _AttendanceService.GetAttendanceByIdAsync(id);
            if (Attendance == null)
            {
                return NotFound();
            }
            return Ok(Attendance);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAttendance(AttendanceModel Attendance)
        {
            var createdAttendance = await _AttendanceService.CreateAttendanceAsync(Attendance);
            return CreatedAtAction(nameof(GetAttendance), new { id = createdAttendance.AttendanceId }, createdAttendance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendance(int id, AttendanceModel Attendance)
        {
            if (id != Attendance.AttendanceId)
            {
                return BadRequest();
            }

            var success = await _AttendanceService.UpdateAttendanceAsync(Attendance);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            var success = await _AttendanceService.DeleteAttendanceAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
