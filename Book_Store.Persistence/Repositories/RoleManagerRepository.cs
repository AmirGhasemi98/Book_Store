using Book_Store.Application.Contracts.Identity;
using Book_Store.Application.DTOs.Role;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<string> Create(IdentityRole<int> role)
        {
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded) return "عملیات با موفقیت انجام شد.";

            return result.Errors.First().Description;
        }

        public async Task<string> Update(IdentityRole<int> role)
        {
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded) return "عملیات با موفقیت انجام شد.";

            return result.Errors.First().Description;
        }

        public async Task<string> Delete(IdentityRole<int> role)
        {
            await _roleManager.DeleteAsync(role);
            return "عملیات با موفقیت انجام شد.";
        }
    }
}
