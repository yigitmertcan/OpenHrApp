using HrApp.Models;

namespace HrApp.Interfaces.Services
{
    public interface IUserService
    {
        public Task<UserModel> CreateUserAsync(UserRequest User);
        public Task<List<UserModel>> GetAllUsersAsync();
        public Task<UserModel> GetUserByIdAsync(int id);
        public Task<bool> UpdateUserAsync(UserModel User);
        public Task<bool> DeleteUserAsync(int id);

    }
}
