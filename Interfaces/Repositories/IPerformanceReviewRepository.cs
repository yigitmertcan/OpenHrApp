using HrApp.Models;

namespace HrApp.Interfaces.Repositories
{
    public interface IPerformanceReviewRepository
    {
        Task<PerformanceReviewModel> GetByIdAsync(int id);
        Task<List<PerformanceReviewModel>> GetAllAsync();
        Task AddAsync(PerformanceReviewModel PerformanceReview);
        Task UpdateAsync(PerformanceReviewModel PerformanceReview);
        Task DeleteAsync(PerformanceReviewModel PerformanceReview);
    }
}
