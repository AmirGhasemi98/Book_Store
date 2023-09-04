using Book_Store.Application.DTOs.Common;

namespace Book_Store.Application.DTOs.Book
{
    public class BookListDto : BaseDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<string> AuthorsFullName { get; set; }
    }
}
