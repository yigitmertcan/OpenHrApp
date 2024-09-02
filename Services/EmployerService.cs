using HrApp.Interfaces.Repositories;
using HrApp.Interfaces.Services;
using HrApp.Models;

namespace HrApp.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly IEmployerRepository _EmployerRepository;

        public EmployerService(IEmployerRepository EmployerRepository)
        {
            _EmployerRepository = EmployerRepository;
        }

        public async Task<EmployerModel> CreateEmployerAsync(EmployerModel Employer)
        {
            await _EmployerRepository.AddAsync(Employer);
            return Employer;
        }

        public async Task<List<EmployerModel>> GetAllEmployersAsync()
        {
            return await _EmployerRepository.GetAllAsync();
        }

        public async Task<EmployerModel> GetEmployerByIdAsync(int id)
        {
            return await _EmployerRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateEmployerAsync(EmployerModel Employer)
        {
            var existingEmployer = await _EmployerRepository.GetByIdAsync(Employer.EmployeeId);
            if (existingEmployer == null)
            {
                return false;
            }

            existingEmployer.EmployeeId = Employer.EmployeeId;

            await _EmployerRepository.UpdateAsync(existingEmployer);
            return true;
        }

        public async Task<bool> DeleteEmployerAsync(int id)
        {
            var Employer = await _EmployerRepository.GetByIdAsync(id);
            if (Employer == null)
            {
                return false;
            }

            await _EmployerRepository.DeleteAsync(Employer);
            return true;
        }
    }
}
