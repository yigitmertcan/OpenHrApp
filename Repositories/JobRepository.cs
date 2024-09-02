using HrApp.Contexts;
using HrApp.Interfaces.Repositories;
using HrApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HrApp.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly HrDBContext _context;

        public JobRepository(HrDBContext context)
        {
            _context = context;
        }

        public async Task<JobModel> GetByIdAsync(int id)
        {
            return await _context.Job.FindAsync(id);
        }

        public async Task<List<JobModel>> GetAllAsync()
        {
            return await _context.Job.ToListAsync();
        }

        public async Task AddAsync(JobModel product)
        {
            await _context.Job.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(JobModel product)
        {
            _context.Job.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(JobModel product)
        {
            _context.Job.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
