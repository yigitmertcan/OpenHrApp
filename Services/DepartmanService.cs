using HrApp.Interfaces.Repositories;
using HrApp.Interfaces.Services;
using HrApp.Models;

namespace HrApp.Services
{
    public class DepartmanService : IDepartmanService
    {
        private readonly IDepartmanRepository _DepartmanRepository;

        public DepartmanService(IDepartmanRepository DepartmanRepository)
        {
            _DepartmanRepository = DepartmanRepository;
        }

        public async Task<DepartmanModel> CreateDepartmanAsync(DepartmanModel Departman)
        {
            await _DepartmanRepository.AddAsync(Departman);
            return Departman;
        }

        public async Task<List<DepartmanModel>> GetAllDepartmansAsync()
        {
            return await _DepartmanRepository.GetAllAsync();
        }

        public async Task<DepartmanModel> GetDepartmanByIdAsync(int id)
        {
            return await _DepartmanRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateDepartmanAsync(DepartmanModel Departman)
        {
            var existingDepartman = await _DepartmanRepository.GetByIdAsync(Departman.DepartmantId);
            if (existingDepartman == null)
            {
                return false;
            }

            existingDepartman.DepartmantId = Departman.DepartmantId;

            await _DepartmanRepository.UpdateAsync(existingDepartman);
            return true;
        }

        public async Task<bool> DeleteDepartmanAsync(int id)
        {
            var Departman = await _DepartmanRepository.GetByIdAsync(id);
            if (Departman == null)
            {
                return false;
            }

            await _DepartmanRepository.DeleteAsync(Departman);
            return true;
        }
    }
}
