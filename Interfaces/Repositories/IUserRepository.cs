using HrApp.Models;

namespace HrApp.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> GetByIdAsync(int id);
        Task<List<UserModel>> GetAllAsync();
        Task AddAsync(UserModel User);
        Task UpdateAsync(UserModel User);
        Task DeleteAsync(UserModel User);
    }
}
