using HrApp.Models;

namespace HrApp.Interfaces.Services
{
    public interface IJobService
    {
        public Task<JobModel> CreateJobAsync(JobModel Job);
        public Task<List<JobModel>> GetAllJobsAsync();
        public Task<JobModel> GetJobByIdAsync(int id);
        public Task<bool> UpdateJobAsync(JobModel Job);
        public Task<bool> DeleteJobAsync(int id);

    }
}
