using HrApp.Models;

namespace HrApp.Interfaces.Repositories
{
    public interface IJobRepository
    {
        Task<JobModel> GetByIdAsync(int id);
        Task<List<JobModel>> GetAllAsync();
        Task AddAsync(JobModel Job);
        Task UpdateAsync(JobModel Job);
        Task DeleteAsync(JobModel Job);
    }
}
