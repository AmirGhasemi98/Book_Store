using Book_Store.Application.DTOs.Common;

namespace Book_Store.Application.DTOs.Author
{
    public class UpdateAuthorDto : BaseDto, IAuthorDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
