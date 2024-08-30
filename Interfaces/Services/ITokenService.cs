using HrApp.Dtos.Requests;
using HrApp.Dtos.Responses;

namespace HrApp.Interfaces.Services
{
    public interface ITokenService
    {
        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
    }
}
