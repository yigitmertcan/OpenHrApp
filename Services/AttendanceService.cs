﻿using AutoMapper;
using HrApp.Dtos.Requests;
using HrApp.Interfaces.Repositories;
using HrApp.Interfaces.Services;
using HrApp.Models;

namespace HrApp.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _AttendanceRepository;
        private readonly IMapper _mapper;

        public AttendanceService(IAttendanceRepository AttendanceRepository, IMapper mapper)
        {
            _AttendanceRepository = AttendanceRepository;
            _mapper = mapper;
        }

        public async Task<AttendanceModel> CreateAttendanceAsync(AttendanceRequest Attendance)
        {
            AttendanceModel attendanceModel = _mapper.Map<AttendanceModel>(Attendance);
            await _AttendanceRepository.AddAsync(attendanceModel);
            return attendanceModel;
        }

        public async Task<List<AttendanceModel>> GetAllAttendancesAsync()
        {
            return await _AttendanceRepository.GetAllAsync();
        }

        public async Task<AttendanceModel> GetAttendanceByIdAsync(int id)
        {
            return await _AttendanceRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAttendanceAsync(AttendanceModel Attendance)
        {
            var existingAttendance = await _AttendanceRepository.GetByIdAsync(Attendance.AttendanceId);
            if (existingAttendance == null)
            {
                return false;
            }

            existingAttendance.AttendanceId = Attendance.AttendanceId;

            await _AttendanceRepository.UpdateAsync(existingAttendance);
            return true;
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            var Attendance = await _AttendanceRepository.GetByIdAsync(id);
            if (Attendance == null)
            {
                return false;
            }

            await _AttendanceRepository.DeleteAsync(Attendance);
            return true;
        }
    }
}
