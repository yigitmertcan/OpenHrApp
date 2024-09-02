using HrApp.Contexts;
using HrApp.Interfaces.Repositories;
using HrApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HrApp.Repositories
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly HrDBContext _context;

        public EmployerRepository(HrDBContext context)
        {
            _context = context;
        }

        public async Task<EmployerModel> GetByIdAsync(int id)
        {
            return await _context.Employer.FindAsync(id);
        }

        public async Task<List<EmployerModel>> GetAllAsync()
        {
            return await _context.Employer.ToListAsync();
        }

        public async Task AddAsync(EmployerModel product)
        {
            await _context.Employer.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployerModel product)
        {
            _context.Employer.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(EmployerModel product)
        {
            _context.Employer.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
