using Book_Store.Application.DTOs.Common;
using Book_Store.Application.DTOs.Role;

namespace Book_Store.Application.DTOs.User
{
    public class UserDetailDto : BaseDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public List<RoleDto> Roles { get; set; }
    }
}
