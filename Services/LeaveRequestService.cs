using HrApp.Interfaces.Repositories;
using HrApp.Interfaces.Services;
using HrApp.Models;

namespace HrApp.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _LeaveRequestRepository;

        public LeaveRequestService(ILeaveRequestRepository LeaveRequestRepository)
        {
            _LeaveRequestRepository = LeaveRequestRepository;
        }

        public async Task<LeaveRequestModel> CreateLeaveRequestAsync(LeaveRequestModel LeaveRequest)
        {
            await _LeaveRequestRepository.AddAsync(LeaveRequest);
            return LeaveRequest;
        }

        public async Task<List<LeaveRequestModel>> GetAllLeaveRequestsAsync()
        {
            return await _LeaveRequestRepository.GetAllAsync();
        }

        public async Task<LeaveRequestModel> GetLeaveRequestByIdAsync(int id)
        {
            return await _LeaveRequestRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateLeaveRequestAsync(LeaveRequestModel LeaveRequest)
        {
            var existingLeaveRequest = await _LeaveRequestRepository.GetByIdAsync(LeaveRequest.LeaveRequestId);
            if (existingLeaveRequest == null)
            {
                return false;
            }

            await _LeaveRequestRepository.UpdateAsync(existingLeaveRequest);
            return true;
        }

        public async Task<bool> DeleteLeaveRequestAsync(int id)
        {
            var LeaveRequest = await _LeaveRequestRepository.GetByIdAsync(id);
            if (LeaveRequest == null)
            {
                return false;
            }

            await _LeaveRequestRepository.DeleteAsync(LeaveRequest);
            return true;
        }
    }
}
