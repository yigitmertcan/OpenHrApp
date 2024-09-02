using HrApp.Contexts;
using HrApp.Interfaces.Repositories;
using HrApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HrApp.Repositories
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly HrDBContext _context;

        public SalaryRepository(HrDBContext context)
        {
            _context = context;
        }

        public async Task<SalaryModel> GetByIdAsync(int id)
        {
            return await _context.Salary.FindAsync(id);
        }

        public async Task<List<SalaryModel>> GetAllAsync()
        {
            return await _context.Salary.ToListAsync();
        }

        public async Task AddAsync(SalaryModel product)
        {
            await _context.Salary.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SalaryModel product)
        {
            _context.Salary.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(SalaryModel product)
        {
            _context.Salary.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
