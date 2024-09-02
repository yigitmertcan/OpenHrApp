using HrApp.Models;

namespace HrApp.Interfaces.Repositories
{
    public interface ILeaveRequestRepository
    {
        Task<LeaveRequestModel> GetByIdAsync(int id);
        Task<List<LeaveRequestModel>> GetAllAsync();
        Task AddAsync(LeaveRequestModel LeaveRequest);
        Task UpdateAsync(LeaveRequestModel LeaveRequest);
        Task DeleteAsync(LeaveRequestModel LeaveRequest);
    }
}
