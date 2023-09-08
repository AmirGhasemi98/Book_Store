using Book_Store.Domain.Identity;

namespace Book_Store.Application.Contracts.Persistence
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken>
    {
        Task<RefreshToken> GetRefreshToken(string refreshToken);
    }
}
