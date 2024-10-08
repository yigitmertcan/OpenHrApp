﻿using HrApp.Dtos.Requests;
using HrApp.Models;

namespace HrApp.Interfaces.Services
{
    public interface ITrainingService
    {
        public Task<TrainingModel> CreateTrainingAsync(TrainingRequest Training);
        public Task<List<TrainingModel>> GetAllTrainingsAsync();
        public Task<TrainingModel> GetTrainingByIdAsync(int id);
        public Task<bool> UpdateTrainingAsync(TrainingModel Training);
        public Task<bool> DeleteTrainingAsync(int id);

    }
}
