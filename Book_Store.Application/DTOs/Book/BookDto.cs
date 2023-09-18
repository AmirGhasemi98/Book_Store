using Book_Store.Application.DTOs.Author;
using Book_Store.Application.DTOs.Category;
using Book_Store.Application.DTOs.Common;
using Book_Store.Application.DTOs.Publisher;
using Book_Store.Application.DTOs.Translator;

namespace Book_Store.Application.DTOs.Book
{
    public class BookDto : BaseDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Summary { get; set; }

        public double? Price { get; set; }

        public int Inventory { get; set; }

        public int CategoryId { get; set; }

        public CategoryDto Category { get; set; }

        public List<AuthorDto> Authors { get; set; }

        public List<TranslatorDto> Translators { get; set; }

        public int PublisherId { get; set; }

        public PublisherDto Publisher { get; set; }

    }
}
