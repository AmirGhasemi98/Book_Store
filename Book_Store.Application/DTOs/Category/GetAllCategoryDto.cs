namespace Book_Store.Application.DTOs.Category
{
    public class GetAllCategoryDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? ParentId { get; set; }

        public List<GetAllCategoryDto> Children { get; set; }
    }
}
