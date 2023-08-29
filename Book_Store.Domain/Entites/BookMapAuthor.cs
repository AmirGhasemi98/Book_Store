namespace Book_Store.Domain.Entites
{
    public class BookMapAuthor
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
