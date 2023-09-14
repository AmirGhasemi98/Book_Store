using Book_Store.Application.Contracts.Identity;
using Microsoft.AspNetCore.Identity;

namespace Book_Store.Persistence.Repositories
{
    public class RoleManagerRepository : IRoleManagerRepository
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public RoleManagerRepository(RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<IdentityRole<int>>> GetList()
        {
            return _roleManager.Roles.ToList();
        }

        public async Task<IdentityRole<int>> Get(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            return role;
        }

        public async Task<(List<string>, bool)> Create(IdentityRole<int> role)
        {
            List<string> messages = new List<string>();

            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                messages.Add("عملیات با موفقیت انجام شد.");

                return (messages, true);
            }

            foreach (var err in result.Errors)
            {
                messages.Add(err.Description);
            }

            return (messages, false);
        }

        public async Task<(List<string>, bool)> Update(IdentityRole<int> role)
        {
            List<string> messages = new List<string>();

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                messages.Add("عملیات با موفقیت انجام شد.");
                return (messages, true);
            }

            foreach (var err in result.Errors)
            {
                messages.Add(err.Description);
            }

            return (messages, false);
        }

        public async Task<string> Delete(IdentityRole<int> role)
        {
            await _roleManager.DeleteAsync(role);
            return "عملیات با موفقیت انجام شد.";
        }
    }
}
