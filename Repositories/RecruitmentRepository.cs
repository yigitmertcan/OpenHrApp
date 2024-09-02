using HrApp.Contexts;
using HrApp.Interfaces.Repositories;
using HrApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HrApp.Repositories
{
    public class RecruitmentRepository : IRecruitmentRepository
    {
        private readonly HrDBContext _context;

        public RecruitmentRepository(HrDBContext context)
        {
            _context = context;
        }

        public async Task<RecruitmentModel> GetByIdAsync(int id)
        {
            return await _context.Recruitment.FindAsync(id);
        }

        public async Task<List<RecruitmentModel>> GetAllAsync()
        {
            return await _context.Recruitment.ToListAsync();
        }

        public async Task AddAsync(RecruitmentModel product)
        {
            await _context.Recruitment.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RecruitmentModel product)
        {
            _context.Recruitment.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RecruitmentModel product)
        {
            _context.Recruitment.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
