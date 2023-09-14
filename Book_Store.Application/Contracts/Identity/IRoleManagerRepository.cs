using Microsoft.AspNetCore.Identity;

namespace Book_Store.Application.Contracts.Identity
{
    public interface IRoleManagerRepository
    {
        Task<List<IdentityRole<int>>> GetList();

        Task<IdentityRole<int>> Get(int id);

        Task<string> Create(IdentityRole<int> role);

        Task<string> Update(IdentityRole<int> role);

        Task<string> Delete(IdentityRole<int> role);
    }
}
