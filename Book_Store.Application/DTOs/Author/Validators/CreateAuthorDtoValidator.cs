using FluentValidation;

namespace Book_Store.Application.DTOs.Author.Validators
{
    public class CreateAuthorDtoValidator : AbstractValidator<CreateAuthorDto>
    {
        public CreateAuthorDtoValidator()
        {
            Include(new IAuthorDtoValidator());
        }
    }
}
