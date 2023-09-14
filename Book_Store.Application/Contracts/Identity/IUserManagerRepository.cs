using Book_Store.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Book_Store.Application.Contracts.Identity
{
    public interface IUserManagerRepository
    {
        Task<List<ApplicationUser>> GetList();

        Task<ApplicationUser> Get(int id);

        Task<List<IdentityRole<int>>> GetUserRoles(ApplicationUser user);

        Task<List<string>> AddRoleToUser(ApplicationUser user, List<IdentityRole<int>> roles);

        Task<List<string>> Add(ApplicationUser user, List<IdentityRole<int>> roles, string password);

        Task<List<string>> Edit(ApplicationUser user, List<IdentityRole<int>> roles, string password);

        Task<List<string>> Delete(ApplicationUser user);
    }
}
