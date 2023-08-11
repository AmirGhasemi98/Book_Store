namespace Book_Store.Application.DTOs.Author
{
    public class CreateAuthorDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
