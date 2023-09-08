using Book_Store.Application.Contracts.Persistence;
using Book_Store.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Persistence.Repositories
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshTokenRepository
    {
        private readonly BookStoreDbContext _context;

        public RefreshTokenRepository(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RefreshToken> GetRefreshToken(string refreshToken)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(r => r.Refresh_Token == refreshToken);
        }

        public async Task<List<RefreshToken>> GetUserRefreshTokens(int userId, string jwtTokenId)
        {
            return await _context.RefreshTokens.Where(u => u.UserId == userId && u.JwtTokenId == jwtTokenId).ToListAsync();
        }
    }
}
