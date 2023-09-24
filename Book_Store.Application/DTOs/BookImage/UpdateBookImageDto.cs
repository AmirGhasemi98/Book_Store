using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Application.DTOs.BookImage
{
    public class UpdateBookImageDto
    {
        public int BookId { get; set; }

        public IFormFile Image { get; set; }
    }
}
