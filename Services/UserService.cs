using HrApp.Interfaces.Repositories;
using HrApp.Interfaces.Services;
using HrApp.Mappings;
using HrApp.Models;

namespace HrApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<UserModel> CreateUserAsync(UserRequest User)
        {
            UserModel userModel = UserMapper.ToUser(User);
            await _UserRepository.AddAsync(userModel);
            return userModel;
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            return await _UserRepository.GetAllAsync();
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            return await _UserRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateUserAsync(UserModel User)
        {
            var existingUser = await _UserRepository.GetByIdAsync(User.Id);
            if (existingUser == null)
            {
                return false;
            }

            existingUser.Id = User.Id;

            await _UserRepository.UpdateAsync(existingUser);
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var User = await _UserRepository.GetByIdAsync(id);
            if (User == null)
            {
                return false;
            }

            await _UserRepository.DeleteAsync(User);
            return true;
        }
    }
}
