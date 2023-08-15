namespace Book_Store.Application.DTOs.Author
{
    public interface IAuthorDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
