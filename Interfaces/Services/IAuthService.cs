using HrApp.Dtos.Requests;
using HrApp.Dtos.Responses;

namespace HrApp.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);
    }
}
