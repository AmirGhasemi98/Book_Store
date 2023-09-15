using Book_Store.Application.Contracts.Identity;
using Book_Store.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Persistence.Repositories
{
    public class UserManagerRepository : IUserManagerRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public UserManagerRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<ApplicationUser>> GetList()
        {
            return _userManager.Users.ToList();
        }

        public async Task<ApplicationUser> Get(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return user;
        }

        public async Task<List<IdentityRole<int>>> GetUserRoles(ApplicationUser user)
        {
            var roles = _roleManager.Roles.ToList();

            var userRoless =await _userManager.GetRolesAsync(user);

            return await _roleManager.Roles.Where(r => userRoless.Contains(r.Name)).ToListAsync();
        }

        public async Task<List<string>> Add(ApplicationUser user, List<IdentityRole<int>> roles, string password)
        {
            List<string> messages = new List<string>();

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                if (roles is not null && roles.Any())
                {
                    var roleResult = await AddRoleToUser(user, roles);

                    if (roleResult.Any())
                        return roleResult;
                }

                return messages;
            }

            messages.AddRange(result.Errors.Select(e => e.Description));

            return messages;
        }

        public async Task<List<string>> AddRoleToUser(ApplicationUser user, List<IdentityRole<int>> roles)
        {
            List<string> messages = new List<string>();

            var userRoles = await _userManager.GetRolesAsync(user);

            var removeResult = await _userManager.RemoveFromRolesAsync(user, userRoles);

            if (!removeResult.Succeeded)
            {
                messages.AddRange(removeResult.Errors.Select(e => e.Description));

                return messages;
            }

            if (roles is not null && roles.Any())
            {
                var result = await _userManager.AddToRolesAsync(user, roles.Select(x => x.Name));

                if (result.Succeeded) return messages;

                messages.AddRange(result.Errors.Select(e => e.Description));
            }

            return messages;
        }

        public async Task<List<string>> Edit(ApplicationUser user, List<IdentityRole<int>> roles, string password)
        {
            List<string> messages = new List<string>();

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                if (roles is not null && roles.Any())
                {
                    var roleResult = await AddRoleToUser(user, roles);

                    if (roleResult.Any())
                        return roleResult;
                }

                if (!string.IsNullOrWhiteSpace(password))
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    var passwordResult = await _userManager.ResetPasswordAsync(user, token, password);

                    if (passwordResult.Succeeded)
                    {
                        return messages;
                    }

                    messages.AddRange(passwordResult.Errors.Select(e => e.Description));

                    return messages;
                }

                return messages;
            }

            messages.AddRange(result.Errors.Select(e => e.Description));

            return messages;
        }

        public async Task<List<string>> Delete(ApplicationUser user)
        {
            List<string> messages = new List<string>();

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
                messages.AddRange(result.Errors.Select(e => e.Description));

            return messages;
        }
    }
}
