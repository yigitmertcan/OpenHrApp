using HrApp.Dtos.Requests;
using HrApp.Models;

namespace HrApp.Interfaces.Services
{
    public interface IJobService
    {
        public Task<JobModel> CreateJobAsync(JobRequest Job);
        public Task<List<JobModel>> GetAllJobsAsync();
        public Task<JobModel> GetJobByIdAsync(int id);
        public Task<bool> UpdateJobAsync(JobModel Job);
        public Task<bool> DeleteJobAsync(int id);

    }
}
