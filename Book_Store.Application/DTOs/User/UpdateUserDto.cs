using Book_Store.Application.DTOs.Common;

namespace Book_Store.Application.DTOs.User
{
    public class UpdateUserDto : BaseDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string? Password { get; set; }

        public List<int> RoleIds { get; set; }
    }
}
