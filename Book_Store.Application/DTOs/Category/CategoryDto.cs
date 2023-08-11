using Book_Store.Application.DTOs.Common;
using Book_Store.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Application.DTOs.Category
{
    public class CategoryDto : BaseDto
    {
        public string Title { get; set; }

        public int? ParentId { get; set; }

        public CategoryDto Parent { get; set; }
    }
}
