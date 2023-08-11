using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Application.DTOs.Category
{
    public class CreateCategoryDto
    {
        public string Title { get; set; }

        public int? ParentId { get; set; }
    }
}
