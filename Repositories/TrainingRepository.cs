using HrApp.Contexts;
using HrApp.Interfaces.Repositories;
using HrApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HrApp.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly HrDBContext _context;

        public TrainingRepository(HrDBContext context)
        {
            _context = context;
        }

        public async Task<TrainingModel> GetByIdAsync(int id)
        {
            return await _context.Training.FindAsync(id);
        }

        public async Task<List<TrainingModel>> GetAllAsync()
        {
            return await _context.Training.ToListAsync();
        }

        public async Task AddAsync(TrainingModel training)
        {
            await _context.Training.AddAsync(training);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TrainingModel training)
        {
            _context.Training.Update(training);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TrainingModel training)
        {
            _context.Training.Remove(training);
            await _context.SaveChangesAsync();
        }
    }
}
