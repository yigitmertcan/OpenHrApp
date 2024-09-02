using HrApp.Models;

namespace HrApp.Interfaces.Services
{
    public interface ISalaryService
    {
        public Task<SalaryModel> CreateSalaryAsync(SalaryModel Salary);
        public Task<List<SalaryModel>> GetAllSalarysAsync();
        public Task<SalaryModel> GetSalaryByIdAsync(int id);
        public Task<bool> UpdateSalaryAsync(SalaryModel Salary);
        public Task<bool> DeleteSalaryAsync(int id);

    }
}
