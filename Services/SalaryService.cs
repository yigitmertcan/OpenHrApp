using HrApp.Interfaces.Repositories;
using HrApp.Interfaces.Services;
using HrApp.Models;

namespace HrApp.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _SalaryRepository;

        public SalaryService(ISalaryRepository SalaryRepository)
        {
            _SalaryRepository = SalaryRepository;
        }

        public async Task<SalaryModel> CreateSalaryAsync(SalaryModel Salary)
        {
            await _SalaryRepository.AddAsync(Salary);
            return Salary;
        }

        public async Task<List<SalaryModel>> GetAllSalarysAsync()
        {
            return await _SalaryRepository.GetAllAsync();
        }

        public async Task<SalaryModel> GetSalaryByIdAsync(int id)
        {
            return await _SalaryRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateSalaryAsync(SalaryModel Salary)
        {
            var existingSalary = await _SalaryRepository.GetByIdAsync(Salary.SalaryId);
            if (existingSalary == null)
            {
                return false;
            }

            existingSalary.SalaryId = Salary.SalaryId;

            await _SalaryRepository.UpdateAsync(existingSalary);
            return true;
        }

        public async Task<bool> DeleteSalaryAsync(int id)
        {
            var Salary = await _SalaryRepository.GetByIdAsync(id);
            if (Salary == null)
            {
                return false;
            }

            await _SalaryRepository.DeleteAsync(Salary);
            return true;
        }
    }
}
