using Book_Store.Application.DTOs.User;
using Book_Store.Application.Models.Identity;

namespace Book_Store.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequset requset);

        Task<RegistrationResponse> Register(RegistrationRequest request);

        Task<List<SyncUserDto>> GetUsersForSync();
    }
}
