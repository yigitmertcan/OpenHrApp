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

        public async Task AddAsync(UserModel user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserModel user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserModel user)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
