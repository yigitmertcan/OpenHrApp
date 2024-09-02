using HrApp.Dtos.Requests;
using HrApp.Models;

namespace HrApp.Interfaces.Services
{
    public interface IDepartmanService
    {
        public Task<DepartmanModel> CreateDepartmanAsync(DepartmanRequest Departman);
        public Task<List<DepartmanModel>> GetAllDepartmansAsync();
        public Task<DepartmanModel> GetDepartmanByIdAsync(int id);
        public Task<bool> UpdateDepartmanAsync(DepartmanModel Departman);
        public Task<bool> DeleteDepartmanAsync(int id);

    }
}
