using Book_Store.Application.DTOs.Common;

namespace Book_Store.Application.DTOs.User
{
    public class UserDto : BaseDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }


    }
}
