using HrApp.Interfaces.Repositories;
using HrApp.Interfaces.Services;
using HrApp.Models;

namespace HrApp.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _JobRepository;

        public JobService(IJobRepository JobRepository)
        {
            _JobRepository = JobRepository;
        }

        public async Task<JobModel> CreateJobAsync(JobModel Job)
        {
            await _JobRepository.AddAsync(Job);
            return Job;
        }

        public async Task<List<JobModel>> GetAllJobsAsync()
        {
            return await _JobRepository.GetAllAsync();
        }

        public async Task<JobModel> GetJobByIdAsync(int id)
        {
            return await _JobRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateJobAsync(JobModel Job)
        {
            var existingJob = await _JobRepository.GetByIdAsync(Job.JobId);
            if (existingJob == null)
            {
                return false;
            }

            await _JobRepository.UpdateAsync(existingJob);
            return true;
        }

        public async Task<bool> DeleteJobAsync(int id)
        {
            var Job = await _JobRepository.GetByIdAsync(id);
            if (Job == null)
            {
                return false;
            }

            await _JobRepository.DeleteAsync(Job);
            return true;
        }
    }
}
