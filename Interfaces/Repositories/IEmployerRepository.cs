using HrApp.Models;

namespace HrApp.Interfaces.Repositories
{
    public interface IEmployerRepository
    {
        Task<EmployerModel> GetByIdAsync(int id);
        Task<List<EmployerModel>> GetAllAsync();
        Task AddAsync(EmployerModel Employer);
        Task UpdateAsync(EmployerModel Employer);
        Task DeleteAsync(EmployerModel Employer);
    }
}
