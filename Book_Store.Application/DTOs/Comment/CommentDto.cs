using Book_Store.Application.DTOs.Book;
using Book_Store.Application.DTOs.Common;

namespace Book_Store.Application.DTOs.Comment
{
    public class CommentDto : BaseDto
    {
        public string Text { get; set; }

        public int Rating { get; set; }

        public string UserId { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public int BookId { get; set; }

        public BookDto BookDto { get; set; }
    }
}
