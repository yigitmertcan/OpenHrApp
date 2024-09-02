using HrApp.Contexts;
using HrApp.Interfaces.Repositories;
using HrApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HrApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HrDBContext _context;

        public UserRepository(HrDBContext context)
        {
            _context = context;
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task AddAsync(UserModel product)
        {
            await _context.User.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserModel product)
        {
            _context.User.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserModel product)
        {
            _context.User.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
