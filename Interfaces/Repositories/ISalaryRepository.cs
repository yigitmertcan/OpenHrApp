using HrApp.Models;

namespace HrApp.Interfaces.Repositories
{
    public interface ISalaryRepository
    {
        Task<SalaryModel> GetByIdAsync(int id);
        Task<List<SalaryModel>> GetAllAsync();
        Task AddAsync(SalaryModel Salary);
        Task UpdateAsync(SalaryModel Salary);
        Task DeleteAsync(SalaryModel Salary);
    }
}
