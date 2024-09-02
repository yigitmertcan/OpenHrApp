using AutoMapper;
using HrApp.Dtos.Requests;
using HrApp.Interfaces.Repositories;
using HrApp.Interfaces.Services;
using HrApp.Models;

namespace HrApp.Services
{
    public class PerformanceReviewService : IPerformanceReviewService
    {
        private readonly IPerformanceReviewRepository _PerformanceReviewRepository;
        private readonly IMapper _mapper;

        public PerformanceReviewService(IPerformanceReviewRepository PerformanceReviewRepository, IMapper mapper)
        {
            _PerformanceReviewRepository = PerformanceReviewRepository;
            _mapper = mapper;
        }

        public async Task<PerformanceReviewModel> CreatePerformanceReviewAsync(PerformanceReviewRequest PerformanceReview)
        {
            PerformanceReviewModel performanceReviewModel = _mapper.Map<PerformanceReviewModel>(PerformanceReview);
            await _PerformanceReviewRepository.AddAsync(performanceReviewModel);
            return performanceReviewModel;
        }

        public async Task<List<PerformanceReviewModel>> GetAllPerformanceReviewsAsync()
        {
            return await _PerformanceReviewRepository.GetAllAsync();
        }

        public async Task<PerformanceReviewModel> GetPerformanceReviewByIdAsync(int id)
        {
            return await _PerformanceReviewRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdatePerformanceReviewAsync(PerformanceReviewModel PerformanceReview)
        {
            var existingPerformanceReview = await _PerformanceReviewRepository.GetByIdAsync(PerformanceReview.ReviewId);
            if (existingPerformanceReview == null)
            {
                return false;
            }

            await _PerformanceReviewRepository.UpdateAsync(existingPerformanceReview);
            return true;
        }

        public async Task<bool> DeletePerformanceReviewAsync(int id)
        {
            var PerformanceReview = await _PerformanceReviewRepository.GetByIdAsync(id);
            if (PerformanceReview == null)
            {
                return false;
            }

            await _PerformanceReviewRepository.DeleteAsync(PerformanceReview);
            return true;
        }
    }
}
