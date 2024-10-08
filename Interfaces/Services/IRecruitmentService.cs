﻿using HrApp.Dtos.Requests;
using HrApp.Models;

namespace HrApp.Interfaces.Services
{
    public interface IRecruitmentService
    {
        public Task<RecruitmentModel> CreateRecruitmentAsync(RecruitmentRequest Recruitment);
        public Task<List<RecruitmentModel>> GetAllRecruitmentsAsync();
        public Task<RecruitmentModel> GetRecruitmentByIdAsync(int id);
        public Task<bool> UpdateRecruitmentAsync(RecruitmentModel Recruitment);
        public Task<bool> DeleteRecruitmentAsync(int id);

    }
}
