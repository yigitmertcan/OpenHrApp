using HrApp.Models;

namespace HrApp.Interfaces.Repositories
{
    public interface IRecruitmentRepository
    {
        Task<RecruitmentModel> GetByIdAsync(int id);
        Task<List<RecruitmentModel>> GetAllAsync();
        Task AddAsync(RecruitmentModel Recruitment);
        Task UpdateAsync(RecruitmentModel Recruitment);
        Task DeleteAsync(RecruitmentModel Recruitment);
    }
}
