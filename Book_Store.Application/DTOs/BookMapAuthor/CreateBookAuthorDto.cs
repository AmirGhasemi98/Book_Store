namespace Book_Store.Application.DTOs.BookMapAuthor
{
    public class CreateBookAuthorDto
    {
        public int BookId { get; set; }

        public List<int> AuthorIds { get; set; }

        public bool ForUpdate { get; set; }
    }
}
