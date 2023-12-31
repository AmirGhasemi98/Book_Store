﻿namespace Book_Store.Application.DTOs.Author
{
    public class CreateAuthorDto : IAuthorDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
