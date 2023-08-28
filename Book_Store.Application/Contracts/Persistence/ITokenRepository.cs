using Microsoft.AspNetCore.Identity;

namespace Book_Store.Application.Contracts.Persistence
{
    public interface ITokenRepository : IGenericRepository<IdentityUserToken<int>>
    {
    }
}
