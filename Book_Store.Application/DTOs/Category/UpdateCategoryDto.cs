using Book_Store.Application.DTOs.Common;

namespace Book_Store.Application.DTOs.Category
{
    public class UpdateCategoryDto : BaseDto, ICategoryDto
    {
        public string Title { get; set; }

        public int? ParentId { get; set; }
    }
}
