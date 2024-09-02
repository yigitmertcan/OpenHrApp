using HrApp.Models;

namespace HrApp.Interfaces.Repositories
{
    public interface IDepartmanRepository
    {
        Task<DepartmanModel> GetByIdAsync(int id);
        Task<List<DepartmanModel>> GetAllAsync();
        Task AddAsync(DepartmanModel Departman);
        Task UpdateAsync(DepartmanModel Departman);
        Task DeleteAsync(DepartmanModel Departman);
    }
}
