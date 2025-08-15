using APIApplication.Entities;
using APIApplication.Models.Request;
using APIApplication.Models.Respone;

namespace APIApplication.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User?> RegiserAsync(LoginRequest request);
        Task<TokenRespone?> LoginAsync(LoginRequest request);
        Task<TokenRespone?> RefreshTokensAsync(RefreshTokenRespone request);

        Task<User?> getUserAsync();

    }
}
