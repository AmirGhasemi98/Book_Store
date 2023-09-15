using Microsoft.AspNetCore.Identity;

namespace Book_Store.Application.Contracts.Identity
{
    public interface IRoleManagerRepository
    {
        Task<List<IdentityRole<int>>> GetList();

        Task<List<IdentityRole<int>>> GetList(List<int> ids);

        Task<IdentityRole<int>> Get(int id);

        Task<(List<string>, bool)> Create(IdentityRole<int> role);

        Task<(List<string>, bool)> Update(IdentityRole<int> role);

        Task<string> Delete(IdentityRole<int> role);
    }
}
