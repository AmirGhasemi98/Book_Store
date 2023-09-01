namespace Book_Store.Application.DTOs.BookMapTranslator
{
    public class CreateBookTranslatorDto
    {
        public int BookId { get; set; }

        public List<int> TranslatorIds { get; set; }

        public bool ForUpdate { get; set; }
    }
}
