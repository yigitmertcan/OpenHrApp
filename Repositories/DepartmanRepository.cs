using HrApp.Contexts;
using HrApp.Interfaces.Repositories;
using HrApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HrApp.Repositories
{
    public class DepartmanRepository : IDepartmanRepository
    {
        private readonly HrDBContext _context;

        public DepartmanRepository(HrDBContext context)
        {
            _context = context;
        }

        public async Task<DepartmanModel> GetByIdAsync(int id)
        {
            return await _context.Departmen.FindAsync(id);
        }

        public async Task<List<DepartmanModel>> GetAllAsync()
        {
            return await _context.Departmen.ToListAsync();
        }

        public async Task AddAsync(DepartmanModel product)
        {
            await _context.Departmen.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DepartmanModel product)
        {
            _context.Departmen.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(DepartmanModel product)
        {
            _context.Departmen.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
