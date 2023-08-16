namespace Book_Store.Application.DTOs.Category
{
    public interface ICategoryDto
    {
        public string Title { get; set; }

        public int? ParentId { get; set; }
    }
}
