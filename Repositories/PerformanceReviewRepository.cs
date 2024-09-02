using HrApp.Contexts;
using HrApp.Interfaces.Repositories;
using HrApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HrApp.Repositories
{
    public class PerformanceReviewRepository : IPerformanceReviewRepository
    {
        private readonly HrDBContext _context;

        public PerformanceReviewRepository(HrDBContext context)
        {
            _context = context;
        }

        public async Task<PerformanceReviewModel> GetByIdAsync(int id)
        {
            return await _context.PerformanceReview.FindAsync(id);
        }

        public async Task<List<PerformanceReviewModel>> GetAllAsync()
        {
            return await _context.PerformanceReview.ToListAsync();
        }

        public async Task AddAsync(PerformanceReviewModel product)
        {
            await _context.PerformanceReview.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PerformanceReviewModel product)
        {
            _context.PerformanceReview.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PerformanceReviewModel product)
        {
            _context.PerformanceReview.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
