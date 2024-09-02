using HrApp.Interfaces.Repositories;
using HrApp.Interfaces.Services;
using HrApp.Models;

namespace HrApp.Services
{
    public class RecruitmentService : IRecruitmentService
    {
        private readonly IRecruitmentRepository _RecruitmentRepository;

        public RecruitmentService(IRecruitmentRepository RecruitmentRepository)
        {
            _RecruitmentRepository = RecruitmentRepository;
        }

        public async Task<RecruitmentModel> CreateRecruitmentAsync(RecruitmentModel Recruitment)
        {
            await _RecruitmentRepository.AddAsync(Recruitment);
            return Recruitment;
        }

        public async Task<List<RecruitmentModel>> GetAllRecruitmentsAsync()
        {
            return await _RecruitmentRepository.GetAllAsync();
        }

        public async Task<RecruitmentModel> GetRecruitmentByIdAsync(int id)
        {
            return await _RecruitmentRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateRecruitmentAsync(RecruitmentModel Recruitment)
        {
            var existingRecruitment = await _RecruitmentRepository.GetByIdAsync(Recruitment.RecruitmentId);
            if (existingRecruitment == null)
            {
                return false;
            }

            await _RecruitmentRepository.UpdateAsync(existingRecruitment);
            return true;
        }

        public async Task<bool> DeleteRecruitmentAsync(int id)
        {
            var Recruitment = await _RecruitmentRepository.GetByIdAsync(id);
            if (Recruitment == null)
            {
                return false;
            }

            await _RecruitmentRepository.DeleteAsync(Recruitment);
            return true;
        }
    }
}
