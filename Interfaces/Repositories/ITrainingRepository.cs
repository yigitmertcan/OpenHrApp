using HrApp.Models;

namespace HrApp.Interfaces.Repositories
{
    public interface ITrainingRepository
    {
        Task<TrainingModel> GetByIdAsync(int id);
        Task<List<TrainingModel>> GetAllAsync();
        Task AddAsync(TrainingModel training);
        Task UpdateAsync(TrainingModel training);
        Task DeleteAsync(TrainingModel training);
    }
}
