using HrApp.Contexts;
using HrApp.Interfaces.Repositories;
using HrApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HrApp.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly HrDBContext _context;

        public AttendanceRepository(HrDBContext context)
        {
            _context = context;
        }

        public async Task<AttendanceModel> GetByIdAsync(int id)
        {
            return await _context.Attendance.FindAsync(id);
        }

        public async Task<List<AttendanceModel>> GetAllAsync()
        {
            return await _context.Attendance.ToListAsync();
        }

        public async Task AddAsync(AttendanceModel product)
        {
            await _context.Attendance.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AttendanceModel product)
        {
            _context.Attendance.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(AttendanceModel product)
        {
            _context.Attendance.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
