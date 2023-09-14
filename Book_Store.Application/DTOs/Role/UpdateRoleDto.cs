using Book_Store.Application.DTOs.Common;

namespace Book_Store.Application.DTOs.Role
{
    public class UpdateRoleDto : BaseDto, IRoleDto
    {
        public string Name { get; set; }

    }
}
