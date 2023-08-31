namespace Book_Store.Domain.Entites
{
    public class BookMapTranslator
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int TransLatorId { get; set; }

        public Translator Translator { get; set; }
    }
}
