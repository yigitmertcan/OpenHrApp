using HrApp.Dtos.Requests;
using HrApp.Models;

namespace HrApp.Interfaces.Services
{
    public interface IAttendanceService
    {
        public Task<AttendanceModel> CreateAttendanceAsync(AttendanceRequest Attendance);
        public Task<List<AttendanceModel>> GetAllAttendancesAsync();
        public Task<AttendanceModel> GetAttendanceByIdAsync(int id);
        public Task<bool> UpdateAttendanceAsync(AttendanceModel Attendance);
        public Task<bool> DeleteAttendanceAsync(int id);

    }
}
