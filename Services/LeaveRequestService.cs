using AutoMapper;
using HrApp.Dtos.Requests;
using HrApp.Interfaces.Repositories;
using HrApp.Interfaces.Services;
using HrApp.Models;

namespace HrApp.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _LeaveRequestRepository;
        private readonly IMapper _mapper;

        public LeaveRequestService(ILeaveRequestRepository LeaveRequestRepository, IMapper mapper)
        {
            _LeaveRequestRepository = LeaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequestModel> CreateLeaveRequestAsync(LeaveRequestRequest LeaveRequest)
        {
            LeaveRequestModel leaveRequestModel = _mapper.Map<LeaveRequestModel>(LeaveRequest);
            await _LeaveRequestRepository.AddAsync(leaveRequestModel);
            return leaveRequestModel;
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
