using HrApp.Interfaces.Repositories;
using HrApp.Interfaces.Services;
using HrApp.Models;

namespace HrApp.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _TrainingRepository;

        public TrainingService(ITrainingRepository TrainingRepository)
        {
            _TrainingRepository = TrainingRepository;
        }

        public async Task<TrainingModel> CreateTrainingAsync(TrainingModel Training)
        {
            await _TrainingRepository.AddAsync(Training);
            return Training;
        }

        public async Task<List<TrainingModel>> GetAllTrainingsAsync()
        {
            return await _TrainingRepository.GetAllAsync();
        }

        public async Task<TrainingModel> GetTrainingByIdAsync(int id)
        {
            return await _TrainingRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateTrainingAsync(TrainingModel Training)
        {
            var existingTraining = await _TrainingRepository.GetByIdAsync(Training.TrainingId);
            if (existingTraining == null)
            {
                return false;
            }

            existingTraining.TrainingName = Training.TrainingName;
            existingTraining.Description = Training.Description;

            await _TrainingRepository.UpdateAsync(existingTraining);
            return true;
        }

        public async Task<bool> DeleteTrainingAsync(int id)
        {
            var Training = await _TrainingRepository.GetByIdAsync(id);
            if (Training == null)
            {
                return false;
            }

            await _TrainingRepository.DeleteAsync(Training);
            return true;
        }
    }
}
