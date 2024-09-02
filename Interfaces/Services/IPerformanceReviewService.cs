using HrApp.Dtos.Requests;
using HrApp.Models;

namespace HrApp.Interfaces.Services
{
    public interface IPerformanceReviewService
    {
        public Task<PerformanceReviewModel> CreatePerformanceReviewAsync(PerformanceReviewRequest PerformanceReview);
        public Task<List<PerformanceReviewModel>> GetAllPerformanceReviewsAsync();
        public Task<PerformanceReviewModel> GetPerformanceReviewByIdAsync(int id);
        public Task<bool> UpdatePerformanceReviewAsync(PerformanceReviewModel PerformanceReview);
        public Task<bool> DeletePerformanceReviewAsync(int id);

    }
}
