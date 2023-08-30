using Book_Store.Application.DTOs.Common;
using Microsoft.AspNetCore.Http;

namespace Book_Store.Application.DTOs.Book
{
    public class UpdateBookDto : BaseDto, IBookDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public double? Price { get; set; }

        public int Inventory { get; set; }

        public IFormFile BookImage { get; set; }

        public int CategoryId { get; set; }

        public List<int> AuthorIds { get; set; }

        public int PublisherId { get; set; }
    }
}
