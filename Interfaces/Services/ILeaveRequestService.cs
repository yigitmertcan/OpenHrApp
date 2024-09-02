using HrApp.Dtos.Requests;
using HrApp.Models;

namespace HrApp.Interfaces.Services
{
    public interface ILeaveRequestService
    {
        public Task<LeaveRequestModel> CreateLeaveRequestAsync(LeaveRequestRequest LeaveRequest);
        public Task<List<LeaveRequestModel>> GetAllLeaveRequestsAsync();
        public Task<LeaveRequestModel> GetLeaveRequestByIdAsync(int id);
        public Task<bool> UpdateLeaveRequestAsync(LeaveRequestModel LeaveRequest);
        public Task<bool> DeleteLeaveRequestAsync(int id);

    }
}
