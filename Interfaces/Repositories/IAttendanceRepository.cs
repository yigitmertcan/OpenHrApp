using HrApp.Models;

namespace HrApp.Interfaces.Repositories
{
    public interface IAttendanceRepository
    {
        Task<AttendanceModel> GetByIdAsync(int id);
        Task<List<AttendanceModel>> GetAllAsync();
        Task AddAsync(AttendanceModel Attendance);
        Task UpdateAsync(AttendanceModel Attendance);
        Task DeleteAsync(AttendanceModel Attendance);
    }
}
