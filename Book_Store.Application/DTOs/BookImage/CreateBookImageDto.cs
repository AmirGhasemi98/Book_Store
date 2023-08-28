using Microsoft.AspNetCore.Http;

namespace Book_Store.Application.DTOs.BookImage
{
    public class CreateBookImageDto
    {
        public int BookId { get; set; }

        public IFormFile Image { get; set; }
    }
}
