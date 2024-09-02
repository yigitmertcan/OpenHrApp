using HrApp.Dtos.Requests;
using HrApp.Models;

namespace HrApp.Interfaces.Services
{
    public interface IEmployerService
    {
        public Task<EmployerModel> CreateEmployerAsync(EmployerRequest Employer);
        public Task<List<EmployerModel>> GetAllEmployersAsync();
        public Task<EmployerModel> GetEmployerByIdAsync(int id);
        public Task<bool> UpdateEmployerAsync(EmployerModel Employer);
        public Task<bool> DeleteEmployerAsync(int id);

    }
}
