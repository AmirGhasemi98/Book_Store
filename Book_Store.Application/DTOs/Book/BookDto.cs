using Book_Store.Application.DTOs.Author;
using Book_Store.Application.DTOs.Category;
using Book_Store.Application.DTOs.Common;
using Book_Store.Application.DTOs.Publisher;
using Book_Store.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Application.DTOs.Book
{
    public class BookDto : BaseDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public double? Price { get; set; }

        public int Inventory { get; set; }

        public byte Image { get; set; }

        public int CategoryId { get; set; }

        public CategoryDto Category { get; set; }

        public int AuthorId { get; set; }

        public AuthorDto Author { get; set; }

        public int PublisherId { get; set; }

        public PublisherDto Publisher { get; set; }

    }
}
