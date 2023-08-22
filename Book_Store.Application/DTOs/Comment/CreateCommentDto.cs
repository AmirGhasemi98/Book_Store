using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Application.DTOs.Comment
{
    public class CreateCommentDto : ICommentDto
    {
        public string Text { get; set; }

        public int Rating { get; set; }

        public int BookId { get; set; }
    }
}
