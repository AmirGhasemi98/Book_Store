﻿namespace Book_Store.Application.DTOs.Category
{
    public class CreateCategoryDto : ICategoryDto
    {
        public string Title { get; set; }

        public int? ParentId { get; set; }
    }
}
