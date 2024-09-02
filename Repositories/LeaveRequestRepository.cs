using HrApp.Contexts;
using HrApp.Interfaces.Repositories;
using HrApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HrApp.Repositories
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly HrDBContext _context;

        public LeaveRequestRepository(HrDBContext context)
        {
            _context = context;
        }

        public async Task<LeaveRequestModel> GetByIdAsync(int id)
        {
            return await _context.LeaveRequest.FindAsync(id);
        }

        public async Task<List<LeaveRequestModel>> GetAllAsync()
        {
            return await _context.LeaveRequest.ToListAsync();
        }

        public async Task AddAsync(LeaveRequestModel product)
        {
            await _context.LeaveRequest.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LeaveRequestModel product)
        {
            _context.LeaveRequest.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(LeaveRequestModel product)
        {
            _context.LeaveRequest.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
